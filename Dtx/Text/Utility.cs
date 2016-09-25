namespace Dtx.Text
{
	public static class Utility
	{
		public const string VERSION = "1.0.0";

		static Utility()
		{
		}

		public static string FixText(string text)
		{
			if (text == null)
			{
				return (string.Empty);
			}

			text = text.Trim();

			if (text == string.Empty)
			{
				return (string.Empty);
			}

			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}

			return (text);
		}
	}
}
