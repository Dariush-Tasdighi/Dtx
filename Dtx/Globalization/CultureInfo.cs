namespace Dtx.Globalization
{
	public static class CultureInfo
	{
		static CultureInfo()
		{
		}

		public static int GetCurrentCultureLcid()
		{
			return (System.Threading.Thread.CurrentThread.CurrentCulture.LCID);
		}

		public static string GetCurrentCultureName()
		{
			return (System.Threading.Thread.CurrentThread.CurrentCulture.Name);
		}

		public static Dtx.Globalization.Cultures GetCurrentCulture()
		{
			Cultures enmCulture =
				(Cultures)GetCurrentCultureLcid();

			return (enmCulture);
		}

		public static string GetCssClass(Cultures culture = Cultures.Auto)
		{
			if (culture == Cultures.Auto)
			{
				culture =
					GetCurrentCulture();
			}

			switch (culture)
			{
				case Cultures.Farsi:
				{
					return ("rtl");
				}

				default:
				{
					return ("ltr");
				}
			}
		}
	}
}
