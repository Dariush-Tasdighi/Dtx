namespace Dtx.IO
{
	/// <summary>
	/// Version: 1.0.1
	/// Update Date: 1392/11/08
	/// Developer: Mr. Dariush Tasdighi
	/// </summary>
	public static class Directory
	{
		/// <summary>
		/// Add the tag (<identity impersonate="true"/>) in your web.config file.
		/// </summary>
		public static void SetFullControlForEveryOne(string path)
		{
			try
			{
				System.Security.AccessControl.DirectorySecurity oDirectorySecurity =
					System.IO.Directory.GetAccessControl(path);

				// Using this instead of the "Everyone"
				// string means we work on non-English systems.
				System.Security.Principal.SecurityIdentifier oEveryone =
					new System.Security.Principal.SecurityIdentifier
						(System.Security.Principal.WellKnownSidType.WorldSid, null);

				System.Security.AccessControl.FileSystemAccessRule oFileSystemAccessRule =
					new System.Security.AccessControl.FileSystemAccessRule
						(identity: oEveryone,
						fileSystemRights: System.Security.AccessControl.FileSystemRights.FullControl |
						System.Security.AccessControl.FileSystemRights.Synchronize,
						inheritanceFlags: System.Security.AccessControl.InheritanceFlags.ContainerInherit |
						System.Security.AccessControl.InheritanceFlags.ObjectInherit,
						propagationFlags: System.Security.AccessControl.PropagationFlags.None,
						type: System.Security.AccessControl.AccessControlType.Allow);

				oDirectorySecurity.AddAccessRule(oFileSystemAccessRule);

				System.IO.Directory.SetAccessControl
					(path: path, directorySecurity: oDirectorySecurity);
			}
			catch (System.Exception ex)
			{
				string strErrorMessage = ex.Message;
			}
		}

		public static void Copy(string sourcePathName, string destinationPathName, bool copySubDirectories)
		{
			// Get the subdirectories for the specified directory.
			System.IO.DirectoryInfo oDirectory =
				new System.IO.DirectoryInfo(sourcePathName);

			System.IO.DirectoryInfo[] oDirectories = oDirectory.GetDirectories();

			if (oDirectory.Exists == false)
			{
				throw (new System.IO.DirectoryNotFoundException(
					"Source directory does not exist or could not be found: "
					+ sourcePathName));
			}

			// If the destination directory doesn't exist, create it. 
			if (System.IO.Directory.Exists(destinationPathName) == false)
			{
				System.IO.Directory.CreateDirectory(destinationPathName);
			}

			// Get the files in the directory and copy them to the new location.
			System.IO.FileInfo[] oFiles = oDirectory.GetFiles();

			foreach (System.IO.FileInfo oFile in oFiles)
			{
				string strTempPath =
					System.IO.Path.Combine(destinationPathName, oFile.Name);

				oFile.CopyTo(strTempPath, false);
			}

			// If copying subdirectories, copy them and their contents to new location. 
			if (copySubDirectories)
			{
				foreach (System.IO.DirectoryInfo oSubDirectory in oDirectories)
				{
					string strTempPath =
						System.IO.Path.Combine(destinationPathName, oSubDirectory.Name);

					Copy(oSubDirectory.FullName, strTempPath, copySubDirectories);
				}
			}
		}
	}
}
