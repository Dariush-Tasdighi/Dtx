namespace Dtx.Security
{
	public static class Hashing
	{
		static Hashing()
		{
		}

		public static string GetMD5(string value)
		{
			if (Dtx.String.IsNullOrEmptyOrWhiteSpace(value))
			{
				return (string.Empty);
			}

			try
			{
				System.Security.Cryptography.MD5 oHash =
					System.Security.Cryptography.MD5.Create();

				byte[] bytInputs =
					System.Text.Encoding.ASCII.GetBytes(value);

				byte[] bytHashes = oHash.ComputeHash(bytInputs);

				// Convert the byte array to hexadecimal string
				System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();

				for (int intIndex = 0; intIndex < bytHashes.Length; intIndex++)
				{
					oStringBuilder.Append(bytHashes[intIndex].ToString("X2"));

					// To force the hex string to lower-case letters instead of
					// upper-case, use he following line instead:
					// sb.Append(hashBytes[i].ToString("x2")); 
				}

				return (oStringBuilder.ToString());

				//return (System.Web.Security.FormsAuthentication
				//	.HashPasswordForStoringInConfigFile(value, "MD5"));
			}
			catch
			{
				return (string.Empty);
			}
		}

		public static string GetSha1(string value)
		{
			if (Dtx.String.IsNullOrEmptyOrWhiteSpace(value))
			{
				return (string.Empty);
			}

			try
			{
				System.Security.Cryptography.SHA1 oHash =
					System.Security.Cryptography.SHA1.Create();

				byte[] bytInputs =
					System.Text.Encoding.ASCII.GetBytes(value);

				byte[] bytHashes = oHash.ComputeHash(bytInputs);

				// Convert the byte array to hexadecimal string
				System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();

				for (int intIndex = 0; intIndex < bytHashes.Length; intIndex++)
				{
					oStringBuilder.Append(bytHashes[intIndex].ToString("X2"));

					// To force the hex string to lower-case letters instead of
					// upper-case, use he following line instead:
					// sb.Append(hashBytes[i].ToString("x2")); 
				}

				return (oStringBuilder.ToString());

				//return (System.Web.Security.FormsAuthentication
				//	.HashPasswordForStoringInConfigFile(value, "SHA1"));
			}
			catch
			{
				return (string.Empty);
			}
		}

		private static byte[] ConvertStringToByteArray(string data)
		{
			return (new System.Text.UnicodeEncoding()).GetBytes(data);
		}

		private static System.IO.FileStream GetFileStream(string pathName)
		{
			return (new System.IO.FileStream
				(pathName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite));
		}

		public static string GetMD5ByPathName(string pathName)
		{
			string strResult = string.Empty;

			System.Security.Cryptography.MD5CryptoServiceProvider
				oMD5CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();

			System.IO.FileStream oFileStream = null;

			try
			{
				oFileStream = GetFileStream(pathName);

				byte[] bytHashValues =
					oMD5CryptoServiceProvider.ComputeHash(oFileStream);

				strResult =
					System.BitConverter.ToString(bytHashValues).Replace("-", string.Empty);
			}
			catch
			{
			}
			finally
			{
				if (oFileStream != null)
				{
					//oFileStream.Close();
					oFileStream.Dispose();
					oFileStream = null;
				}
			}

			return (strResult);
		}

		public static string GetSha1ByPathName(string pathName)
		{
			string strResult = string.Empty;

			System.Security.Cryptography.SHA1CryptoServiceProvider
				oSHA1CryptoServiceProvider = new System.Security.Cryptography.SHA1CryptoServiceProvider();

			System.IO.FileStream oFileStream = null;

			try
			{
				oFileStream = GetFileStream(pathName);

				byte[] bytHashValues =
					oSHA1CryptoServiceProvider.ComputeHash(oFileStream);

				strResult =
					System.BitConverter.ToString(bytHashValues).Replace("-", string.Empty);
			}
			catch
			{
			}
			finally
			{
				if (oFileStream != null)
				{
					//oFileStream.Close();
					oFileStream.Dispose();
					oFileStream = null;
				}
			}

			return (strResult);
		}
	}
}
