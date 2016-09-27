namespace Dtx.Security
{
	public static class Utility
	{
		static Utility()
		{
		}

		public static void ToggleConnectionStringProtection(string path, bool protect)
		{
			// Define the Dpapi provider name.
			string strProvider = "DataProtectionConfigurationProvider";
			// string strProvider = "RSAProtectedConfigurationProvider";

			System.Configuration.Configuration oConfiguration = null;
			System.Configuration.ConnectionStringsSection oSection = null;

			try
			{
				// Open the configuration file and retrieve the connectionStrings section.

				// For Windows!
				//oConfiguration =
				//	System.Configuration.ConfigurationManager.OpenExeConfiguration(path);

				// For Web!
				oConfiguration =
					System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(path);

				if (oConfiguration != null)
				{
					bool blnChanged = false;

					oSection =
						oConfiguration.GetSection("connectionStrings")
						as System.Configuration.ConnectionStringsSection;

					if (oSection != null)
					{
						if ((oSection.ElementInformation.IsLocked == false) &&
							(oSection.SectionInformation.IsLocked == false))
						{
							if (protect)
							{
								if (oSection.SectionInformation.IsProtected == false)
								{
									blnChanged = true;

									// Encrypt the section.
									oSection.SectionInformation.ProtectSection(strProvider);
								}
							}
							else
							{
								if (oSection.SectionInformation.IsProtected)
								{
									blnChanged = true;

									// Remove encryption.
									oSection.SectionInformation.UnprotectSection();
								}
							}
						}

						if (blnChanged)
						{
							// Indicates whether the associated configuration section 
							// will be saved even if it has not been modified.
							oSection.SectionInformation.ForceSave = true;

							// Save the current configuration.
							oConfiguration.Save();
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				throw (ex);
			}
			finally
			{
			}
		}

		public static byte[] Encrypt(byte[] data, byte[] key)
		{
			System.Security.Cryptography.DESCryptoServiceProvider
				oDESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();

			oDESCryptoServiceProvider.Mode =
				System.Security.Cryptography.CipherMode.ECB;

			oDESCryptoServiceProvider.Padding =
				System.Security.Cryptography.PaddingMode.Zeros;

			System.IO.MemoryStream oMemoryStream = new System.IO.MemoryStream();

			System.Security.Cryptography.CryptoStream oCryptoStream =
				new System.Security.Cryptography.CryptoStream(oMemoryStream, oDESCryptoServiceProvider.CreateEncryptor(key, null),
					System.Security.Cryptography.CryptoStreamMode.Write);

			oCryptoStream.Write(data, 0, data.Length);

			oCryptoStream.FlushFinalBlock();

			oMemoryStream.Position = 0;

			byte[] bytResult = oMemoryStream.ToArray();

			oMemoryStream.Close();

			oCryptoStream.Close();

			return (bytResult);
		}

		public static string Encrypt(string data, string key)
		{
			key = key.Replace(" ", string.Empty);

			byte[] bytKey =
				ConvertHexToBinary(key);

			byte[] bytData =
				System.Text.Encoding.Default.GetBytes(data);

			byte[] bytResult = Encrypt(bytData, bytKey);

			string strResult =
				ConvertBinaryToHex(bytResult);

			return (strResult);
		}

		public static byte[] Decrypt(byte[] data, byte[] key)
		{
			System.Security.Cryptography.DESCryptoServiceProvider
				oDESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();

			oDESCryptoServiceProvider.Mode =
				System.Security.Cryptography.CipherMode.ECB;

			oDESCryptoServiceProvider.Padding =
				System.Security.Cryptography.PaddingMode.Zeros;

			System.IO.MemoryStream oMemoryStream = new System.IO.MemoryStream();

			System.Security.Cryptography.CryptoStream oCryptoStream =
				new System.Security.Cryptography.CryptoStream(oMemoryStream, oDESCryptoServiceProvider.CreateDecryptor(key, key),
					System.Security.Cryptography.CryptoStreamMode.Write);

			oCryptoStream.Write(data, 0, data.Length);

			oCryptoStream.FlushFinalBlock();

			oMemoryStream.Position = 0;

			byte[] bytResult = oMemoryStream.ToArray();

			oMemoryStream.Close();

			oCryptoStream.Close();

			return (bytResult);
		}

		public static string Decrypt(string data, string key)
		{
			key = key.Replace(" ", string.Empty);

			data = data.Replace(" ", string.Empty);

			byte[] bytKey =
				ConvertHexToBinary(key);

			byte[] bytData =
				ConvertHexToBinary(data);

			byte[] bytResult = Decrypt(bytData, bytKey);

			string strResult =
				System.Text.Encoding.Default.GetString(bytResult);

			strResult =
				strResult.TrimEnd((char)0, (char)1, (char)2, (char)3, (char)4, (char)5, (char)6, (char)7, (char)8, (char)9);

			return (strResult);
		}

		public static byte[] ConvertHexToBinary(string hex)
		{
			hex = hex.ToUpper();

			int i, iMax;

			byte[] pRetData;

			iMax = hex.Length;

			string strTemp;

			int nIndex = 0;

			if ((iMax & 1) == 1)
			{
				strTemp = hex + "0";

				++iMax;
			}
			else
			{
				strTemp = hex;
			}

			pRetData = new byte[iMax >> 1];

			for (i = 0; i < iMax; i += 2)
			{
				if (strTemp[i] < 0x40)
				{
					pRetData[nIndex] = (byte)(strTemp[i] - '0');
				}
				else
				{
					pRetData[nIndex] = (byte)(strTemp[i] - '7');
				}

				pRetData[nIndex] <<= 4;

				if (strTemp[i + 1] < 0x40)
				{
					pRetData[nIndex] |= (byte)(strTemp[i + 1] - '0');
				}
				else
				{
					pRetData[nIndex] |= (byte)(strTemp[i + 1] - '7');
				}

				++nIndex;
			}

			return (pRetData);
		}

		public static string ConvertBinaryToHex(byte[] data)
		{
			if (data == null)
			{
				return ("null");
			}
			else
			{
				System.Text.StringBuilder sb =
					new System.Text.StringBuilder(data.Length << 1);

				foreach (byte b in data)
				{
					sb.AppendFormat("{0:X2}", b);
				}

				return (sb.ToString());
			}
		}
	}
}
