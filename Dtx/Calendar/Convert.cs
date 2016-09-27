namespace Dtx.Calendar
{
	/// <summary>
	/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
	/// </summary>
	public static class Convert
	{
		#region Not Used!
		///// <summary>
		///// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		///// </summary>
		//private static bool IsCivilLeapYear(int year)
		//{
		//    if (year < 1582)
		//        return (Dtx.Math.GetRemainder(year, 4) == 0);
		//    else
		//        return ((Dtx.Math.GetRemainder(year, 4) == 0) || (Dtx.Math.GetRemainder(year, 100) == 0) || (Dtx.Math.GetRemainder(year, 400) == 0)); // ????? Must be XOR!!!!!
		//}

		///// <summary>
		///// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		///// </summary>
		//private static void ConvertCivilToJulian(ref int year, ref int month, ref int day)
		//{
		//    ConvertJdnToJulian(ConvertCivilToJdn(year, month, day), ref year, ref month, ref day);
		//}

		///// <summary>
		///// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		///// </summary>
		//private static void ConvertJulianToCivil(ref int year, ref int month, ref int day)
		//{
		//    ConvertJdnToCivil(ConvertJulianToJdn(year, month, day), ref year, ref month, ref day);
		//}

		///// <summary>
		///// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		///// </summary>
		//private static void ConvertJulianToPersion(ref int year, ref int month, ref int day)
		//{
		//    ConvertJdnToPersian(ConvertJulianToJdn(year, month, day), ref year, ref month, ref day);
		//}

		///// <summary>
		///// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		///// </summary>
		//private static void ConvertPersionToJulian(ref int year, ref int month, ref int day)
		//{
		//    ConvertJdnToJulian(ConvertPersianToJdn(year, month, day), ref year, ref month, ref day);
		//}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		//public static bool Check(int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
		//{
		//    bool blnResult = true;

		//    System.DateTime dtmEnd = new System.DateTime(endYear, endMonth, endDay);
		//    System.DateTime dtmStart = new System.DateTime(startYear, startMonth, startDay);

		//    System.DateTime dtmCurrent = dtmStart;

		//    while (dtmCurrent <= dtmEnd)
		//    {
		//        PersianDate oPersianDate = CivilToPersion(dtmCurrent.Year, dtmCurrent.Month, dtmCurrent.Day);
		//        System.DateTime oCivilDate = PersionToCivil(oPersianDate.Year, oPersianDate.Month, oPersianDate.Day);

		//        if ((oCivilDate.Year != dtmCurrent.Year) || (oCivilDate.Month != dtmCurrent.Month) || (oCivilDate.Day != dtmCurrent.Day))
		//        {
		//            blnResult = false;
		//            break;
		//        }

		//        dtmCurrent = dtmCurrent.AddDays(1);
		//    }

		//    return (blnResult);
		//}
		#endregion /Not Used!

		#region Private Static Methods
		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		private static int Ceil(decimal number)
		{
			if (number == (int)number)
				return ((int)number);
			else
				if (number >= 0)
					return ((int)(number + 1));
				else
					return (-((int)(-number + 1)));
		}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		private static void ConvertCivilToPersion(ref int year, ref int month, ref int day)
		{
			ConvertJdnToPersian(ConvertCivilToJdn(year, month, day), ref year, ref month, ref day);
		}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		private static void ConvertPersionToCivil(ref int year, ref int month, ref int day)
		{
			ConvertJdnToCivil(ConvertPersianToJdn(year, month, day), ref year, ref month, ref day);
		}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		private static int ConvertCivilToJdn(int year, int month, int day)
		{
			int intReturn = 0;

			if ((year > 1582) || ((year == 1582) && (month > 10)) || ((year == 1582) && (month == 10) && (day > 14)))
				intReturn = Dtx.Math.GetQuotient((1461 * (year + 4800 + Dtx.Math.GetQuotient((month - 14), 12))), 4) + Dtx.Math.GetQuotient((367 * (month - 2 - 12 * (Dtx.Math.GetQuotient((month - 14), 12)))), 12) - Dtx.Math.GetQuotient((3 * (Dtx.Math.GetQuotient((year + 4900 + Dtx.Math.GetQuotient((month - 14), 12)), 100))), 4) + day - 32075;
			else
				intReturn = ConvertJulianToJdn(year, month, day);

			return (intReturn);
		}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		private static int ConvertPersianToJdn(int year, int month, int day)
		{
			const int PERSIAN_EPOCH = 1948321;

			int mdays, epbase, epyear, intReturn;

			if (year >= 0)
				epbase = year - 474;
			else
				epbase = year - 473;

			epyear = 474 + Dtx.Math.Mod(epbase, 2820);

			if (month <= 7)
				mdays = (month - 1) * 31;
			else
				mdays = (month - 1) * 30 + 6;

			intReturn = day + mdays + (int)(((epyear * 682) - 110) / 2816) + (epyear - 1) * 365 + (int)(epbase / 2820) * 1029983 + PERSIAN_EPOCH - 1;

			return (intReturn);
		}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		private static int ConvertJulianToJdn(int year, int month, int day)
		{
			int intResult = 367 * year - Dtx.Math.GetQuotient((7 * (year + 5001 + Dtx.Math.GetQuotient((month - 9), 7))), 4) + Dtx.Math.GetQuotient((275 * month), 9) + day + 1729777;
			return (intResult);
		}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		private static void ConvertJdnToPersian(int jdn, ref int year, ref int month, ref int day)
		{
			int depoch, cycle, cyear, ycycle, aux1, aux2, yday;

			depoch = jdn - ConvertPersianToJdn(475, 1, 1);
			cycle = (int)(depoch / 1029983);
			cyear = Dtx.Math.Mod(depoch, 1029983);

			if (cyear == 1029982)
				ycycle = 2820;
			else
			{
				aux1 = (int)(cyear / 366);
				aux2 = Dtx.Math.Mod(cyear, 366);
				ycycle = (int)(((2134 * aux1) + (2816 * aux2) + 2815) / 1028522) + aux1 + 1;
			}

			year = ycycle + (2820 * cycle) + 474;

			if (year <= 0)
				year--;

			yday = (jdn - ConvertPersianToJdn(year, 1, 1)) + 1;

			if (yday <= 186)
				month = Ceil((decimal)yday / 31);
			else
				month = Ceil(((decimal)yday - 6) / 30);

			day = (jdn - ConvertPersianToJdn(year, month, 1)) + 1;
		}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		private static void ConvertJdnToCivil(int jdn, ref int year, ref int month, ref int day)
		{
			int i, j, l, n;

			if (jdn > 2299160)
			{
				l = jdn + 68569;
				n = Dtx.Math.GetQuotient((4 * l), 146097);
				l = l - Dtx.Math.GetQuotient((146097 * n + 3), 4);
				i = Dtx.Math.GetQuotient((4000 * (l + 1)), 1461001);
				l = l - Dtx.Math.GetQuotient((1461 * i), 4) + 31;
				j = Dtx.Math.GetQuotient((80 * l), 2447);
				day = l - Dtx.Math.GetQuotient((2447 * j), 80);
				l = Dtx.Math.GetQuotient(j, 11);
				month = j + 2 - 12 * l;
				year = 100 * (n - 49) + i + l;
			}
			else
				ConvertJdnToJulian(jdn, ref year, ref month, ref day);
		}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		private static void ConvertJdnToJulian(int jdn, ref int year, ref int month, ref int day)
		{
			int i, j, k, l, n;

			j = jdn + 1402;
			k = Dtx.Math.GetQuotient((j - 1), 1461);
			l = j - 1461 * k;
			n = Dtx.Math.GetQuotient((l - 1), 365) - Dtx.Math.GetQuotient(l, 1461);
			i = l - 365 * n + 30;
			j = Dtx.Math.GetQuotient((80 * i), 2447);
			day = i - Dtx.Math.GetQuotient((2447 * j), 80);
			i = Dtx.Math.GetQuotient(j, 11);
			month = j + 2 - 12 * i;
			year = 4 * k + n + i - 4716;
		}
		#endregion /Private Static Methods

		#region Internal Static Methods
		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		internal static System.DayOfWeek GetPersianDayOfWeekIndex(int year, int month, int day)
		{
			ConvertPersionToCivil(ref year, ref month, ref day);

			System.DateTime oDate = new System.DateTime(year, month, day);

			return (oDate.DayOfWeek);
		}
		#endregion /Internal Static Methods

		#region Public Static Methods
		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		public static PersianDate CivilToPersion(int year, int month, int day)
		{
			System.DateTime oDate = new System.DateTime(year, month, day);

			return (CivilToPersion(oDate));
		}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		public static PersianDate CivilToPersion(System.DateTime? date)
		{
			if(date == null)
			{
				return (null);
			}

			int intDay = date.Value.Day;
			int intYear = date.Value.Year;
			int intMonth = date.Value.Month;

			ConvertCivilToPersion(ref intYear, ref intMonth, ref intDay);

			PersianDate oPersianDate = new PersianDate(intYear, intMonth, intDay);
			oPersianDate.DayOfWeek = date.Value.DayOfWeek;

			return (oPersianDate);
		}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		public static System.DateTime PersionToCivil(string date)
		{
			int intDay;
			int intYear;
			int intMonth;

			if (string.IsNullOrEmpty(PersianDate.ParseDate(date, out intYear, out intMonth, out intDay)))
				return (System.DateTime.MinValue);
			else
				return (PersionToCivil(intYear, intMonth, intDay));
		}

		/// <summary>
		/// Dariush Tasdighi - 1386/02/01 - Version 3.0.0
		/// </summary>
		public static System.DateTime PersionToCivil(int year, int month, int day)
		{
			ConvertPersionToCivil(ref year, ref month, ref day);
			return (new System.DateTime(year, month, day));
		}
		#endregion /Public Static Methods
	}
}
