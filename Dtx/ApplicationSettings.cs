namespace Dtx
{
	public static class ApplicationSettings
	{
		static ApplicationSettings()
		{
		}

		public static string GetValue(string key, string defaultValue = "")
		{
			if (defaultValue == null)
			{
				defaultValue = string.Empty;
			}

			// Note: Do not write below code(s)!
			//defaultValue =
			//	defaultValue.Trim();

			if (Dtx.String.IsNullOrEmptyOrWhiteSpace(key))
			{
				return (defaultValue);
			}

			try
			{
				string strData =
					System.Configuration.ConfigurationManager.AppSettings[key];

				return (strData);

				// Note: Do not write below code(s)!
				//if (string.IsNullOrEmpty(strData))
				//{
				//	return (defaultValue);
				//}

				//return (strData.Trim());
			}
			catch
			{
				return (defaultValue);
			}
		}
	}
}
