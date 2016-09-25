namespace Dtx.IO
{
	public static class File
	{
		static File()
		{
		}

		public static string Read(string pathName)
		{
			if (Dtx.String.IsNullOrEmptyOrWhiteSpace(pathName))
			{
				return (string.Empty);
			}

			if (System.IO.File.Exists(pathName) == false)
			{
				return (string.Empty);
			}

			string strResult = string.Empty;

			System.IO.StreamReader oStream = null;

			try
			{
				oStream =
					new System.IO.StreamReader
						(path: pathName, encoding: System.Text.Encoding.UTF8);

				strResult = oStream.ReadToEnd();
			}
			catch
			{
			}
			finally
			{
				if (oStream != null)
				{
					//oStream.Close();
					oStream.Dispose();
					oStream = null;
				}
			}

			return (strResult);
		}

		public static bool Write(string pathName, string text, bool append)
		{
			if (Dtx.String.IsNullOrEmptyOrWhiteSpace(pathName))
			{
				return (false);
			}

			if (text == null)
			{
				text = string.Empty;
			}

			System.IO.StreamWriter oStream = null;

			try
			{
				oStream =
					new System.IO.StreamWriter
						(path: pathName, append: append, encoding: System.Text.Encoding.UTF8);

				oStream.Write(text);

				return (true);
			}
			catch
			{
				return (false);
			}
			finally
			{
				if (oStream != null)
				{
					//oStream.Close();
					oStream.Dispose();
					oStream = null;
				}
			}
		}

		public static bool Append(string pathName, string text)
		{
			return (Write(pathName, text, append: true));
		}

		public static bool Overwrite(string pathName, string text)
		{
			return (Write(pathName, text, append: false));
		}

		public static string GetFileNameByCulture
			(string name, string extension, string cultureName)
		{
			string strFileName = name;

			strFileName =
				string.Format("{0}.{1}.{2}",
				strFileName, cultureName, extension);

			return (strFileName);
		}

		public static string GetFileNameByCurrentCulture(string name, string extension)
		{
			string strFileName =
				GetFileNameByCulture
					(name: name,
					extension: extension,
					cultureName: Dtx.Globalization.CultureInfo.GetCurrentCultureName());

			return (strFileName);
		}

		public static string GetPathNameByCulture
			(string rootRelativePath, string name, string extension, string cultureName)
		{
			string strFileName =
				GetFileNameByCulture
					(name: name,
					extension: extension,
					cultureName: cultureName);

			string strRootRelativePathName =
				string.Format("{0}/{1}", rootRelativePath, strFileName);

			string strPathName =
				System.Web.HttpContext.Current.Server.MapPath(strRootRelativePathName);

			return (strPathName);
		}

		public static string GetPathNameByCurrentCulture
			(string rootRelativePath, string name, string extension)
		{
			string strPathName =
				GetPathNameByCulture
					(rootRelativePath: rootRelativePath,
					name: name,
					extension: extension,
					cultureName: Dtx.Globalization.CultureInfo.GetCurrentCultureName());

			return (strPathName);
		}
	}
}
