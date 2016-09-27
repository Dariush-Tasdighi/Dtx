namespace Dtx.Calendar
{
	public static class Utility
	{
		static Utility()
		{
		}

		public static string DisplayDateTime
			(System.DateTime? dateTime, bool displayTime, string defaultValue = "-----")
		{
			if (dateTime == null)
			{
				return (defaultValue);
			}

			string strResult = string.Empty;

			System.Globalization.CultureInfo oCurrentCultureInfo =
				System.Threading.Thread.CurrentThread.CurrentCulture;

			switch (oCurrentCultureInfo.LCID)
			{
				// فارسی
				case 1065:
				{
					Dtx.Calendar.PersianDate oPersianDate =
						Dtx.Calendar.Convert.CivilToPersion(dateTime.Value);

					strResult =
						oPersianDate.Value1;

					break;
				}

				default:
				{
					//strResult =
					//	string.Format("{0}/{1}/{2}",
					//	dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day);

					strResult =
						dateTime.Value.ToString("yyyy/MM/dd");

					break;
				}
			}

			if (displayTime)
			{
				string strTime = string.Empty;

				switch (oCurrentCultureInfo.LCID)
				{
					// فارسی
					case 1065:
					{
						strTime =
							Dtx.Calendar.PersianDate.GetTime1(dateTime.Value);

						break;
					}

					default:
					{
						int intSe = dateTime.Value.Second;
						int intMi = dateTime.Value.Minute;
						int intHo = dateTime.Value.Hour;

						string strSe = intSe.ToString().PadLeft(totalWidth: 2, paddingChar: '0');
						string strMi = intMi.ToString().PadLeft(totalWidth: 2, paddingChar: '0');
						string strHo = intHo.ToString().PadLeft(totalWidth: 2, paddingChar: '0');

						strTime =
							string.Format("{0}:{1}:{2}", strHo, strMi, strSe);

						break;
					}
				}

				strResult =
					string.Format("{0} [{1}]", strResult, strTime);
			}

			return (strResult);
		}
	}
}
