namespace Dtx
{
	public static class String
	{
		static String()
		{
		}

		public static bool IsNullOrEmptyOrWhiteSpace(string value)
		{
			if (value == null)
			{
				return (true);
			}

			value = value.Trim();

			if (value == string.Empty)
			{
				return (true);
			}

			return (false);
		}

		public static bool Contains(string text, string value, bool ignoreCase = false)
		{
			if (ignoreCase)
			{
				string strText = text.ToLower();
				string strValue = value.ToLower();

				return (strText.Contains(strValue));
			}
			else
			{
				return (text.Contains(value));
			}
		}

		public static bool IsJustInt(string text)
		{
			if (IsNullOrEmptyOrWhiteSpace(text))
			{
				return (false);
			}

			try
			{
				System.Convert.ToInt32(text);

				return (true);
			}
			catch
			{
				return (false);
			}
		}

		public static bool IsNullOrEmptyOrInt(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return (true);
			}

			if (IsJustInt(text))
			{
				return (true);
			}

			return (false);
		}

		public static bool IsJustLong(string text)
		{
			if (IsNullOrEmptyOrWhiteSpace(text))
			{
				return (false);
			}

			try
			{
				System.Convert.ToInt64(text);

				return (true);
			}
			catch
			{
				return (false);
			}
		}

		public static bool IsNullOrEmptyOrLong(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return (true);
			}

			if (IsJustLong(text))
			{
				return (true);
			}

			return (false);
		}
	}
}
