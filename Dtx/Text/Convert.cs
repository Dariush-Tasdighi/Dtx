namespace Dtx.Text
{
	public static class Convert
	{
		static Convert()
		{
		}

		public static string DatabaseToShow(long number)
		{
			return (DatabaseToShow(number.ToString()));
		}

		public static string DatabaseToShow(string text)
		{
			if (Dtx.String.IsNullOrEmptyOrWhiteSpace(text))
			{
				return (string.Empty);
			}

			text = text.Trim();

			System.Text.StringBuilder oResult =
				new System.Text.StringBuilder(text.Length);

			for (int intIndex = 0; intIndex <= text.Length - 1; intIndex++)
			{
				int intCode = System.Convert.ToInt32(text[intIndex]);

				string strNextChar = "";

				if (intIndex < text.Length - 1)
				{
					strNextChar = text[intIndex + 1].ToString();
				}

				switch (intCode)
				{
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
					{
						oResult.Append(System.Convert.ToChar(intCode - '0' + 1776));
						break;
					}

					case 1711:
					{
						oResult.Append(System.Convert.ToChar(1705));
						break;
					}

					case 1604:
					{
						oResult.Append(System.Convert.ToChar(1711));
						break;
					}

					case 1605:
					{
						oResult.Append(System.Convert.ToChar(1604));
						break;
					}

					case 1606:
					{
						oResult.Append(System.Convert.ToChar(1605));
						break;
					}

					case 1607:
					{
						oResult.Append(System.Convert.ToChar(1606));
						break;
					}

					case 1610:
					{
						oResult.Append(System.Convert.ToChar(1607));
						break;
					}

					case 1705:
					{
						if (string.IsNullOrEmpty(strNextChar))
						{
							oResult.Append(System.Convert.ToChar(1740));
						}
						else
						{
							string str = @"÷×`~1!2@3#4$5%6^7&8*9(0)-_=+،؛,[]<.>/؟\{}|ـ«»:abcdefghijklmnopqrstuvwxyz۹۸۷۶۵۴۳۲۱۰" + "‌"; // نيم فاصله;

							str = str.ToUpper();

							if (str.Contains(strNextChar.ToUpper()))
							{
								oResult.Append(System.Convert.ToChar(1740));
							}
							else
							{
								oResult.Append(System.Convert.ToChar(1610));
							}
						}

						break;
					}

					default:
					{
						oResult.Append(System.Convert.ToChar(intCode));
						break;
					}
				}
			}
			return (oResult.ToString());
		}

		public static string ShowToDatabase(string text)
		{
			if (Dtx.String.IsNullOrEmptyOrWhiteSpace(text))
			{
				return (string.Empty);
			}

			text = text.Trim();

			System.Text.StringBuilder oResult =
				new System.Text.StringBuilder(text.Length);

			for (int intIndex = 0; intIndex <= text.Length - 1; intIndex++)
			{
				int intCode = System.Convert.ToInt32(text[intIndex]);

				switch (intCode)
				{
					case 1776:
					case 1777:
					case 1778:
					case 1779:
					case 1780:
					case 1781:
					case 1782:
					case 1783:
					case 1784:
					case 1785:
					{
						oResult.Append(System.Convert.ToChar(intCode - 1776 + '0'));
						break;
					}

					case 1705:
					{
						oResult.Append(System.Convert.ToChar(1711));
						break;
					}

					case 1711:
					{
						oResult.Append(System.Convert.ToChar(1604));
						break;
					}

					case 1604:
					{
						oResult.Append(System.Convert.ToChar(1605));
						break;
					}

					case 1605:
					{
						oResult.Append(System.Convert.ToChar(1606));
						break;
					}

					case 1606:
					{
						oResult.Append(System.Convert.ToChar(1607));
						break;
					}

					case 1607:
					{
						oResult.Append(System.Convert.ToChar(1610));
						break;
					}

					case 1740:
					case 1610:
					{
						oResult.Append(System.Convert.ToChar(1705));
						break;
					}

					default:
					{
						oResult.Append(System.Convert.ToChar(intCode));
						break;
					}
				}
			}
			return (oResult.ToString());
		}

		public static string JustUnicodesToDigits(string number)
		{
			if (number == null)
			{
				return (string.Empty);
			}

			number = number.Trim();

			if (number == string.Empty)
			{
				return (string.Empty);
			}

			System.Text.StringBuilder oResult = new System.Text.StringBuilder();

			for (int intIndex = 0; intIndex <= number.Length - 1; intIndex++)
			{
				char chrCurrent = number[intIndex];

				if ((chrCurrent >= 1776) && (chrCurrent <= 1786))
				{
					oResult.Append(System.Convert.ToChar(chrCurrent - 1776 + '0'));
				}
				else
				{
					oResult.Append(chrCurrent.ToString());
				}
			}

			return (oResult.ToString());
		}

		public static string JustDigitsToUnicodes(long? text)
		{
			if (text.HasValue == false)
			{
				return (string.Empty);
			}
			else
			{
				return (JustDigitsToUnicodes(text.ToString()));
			}
		}

		public static string JustDigitsToUnicodes(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return (string.Empty);
			}

			System.Text.StringBuilder oResult = new System.Text.StringBuilder();

			for (int intIndex = 0; intIndex <= text.Length - 1; intIndex++)
			{
				char chrCurrent = text[intIndex];

				if ((chrCurrent >= '0') && (chrCurrent <= '9'))
				{
					oResult.Append(System.Convert.ToChar(1776 + chrCurrent - '0'));
				}
				else
				{
					oResult.Append(chrCurrent.ToString());
				}
			}

			return (oResult.ToString());
		}

		public static string ToNumberByCulture
			(object value, string numberIsNullCaption = null, string numberIsNotValidCaption = null)
		{
			return (ToFormattedNumberByCulture
				(value: value, numberIsNullCaption: numberIsNullCaption, numberIsNotValidCaption: numberIsNotValidCaption, format: null));
		}

		public static string ToFormattedNumberByCulture
			(object value, string numberIsNullCaption = null, string numberIsNotValidCaption = null, string format = "#,##0")
		{
			if (value == null)
			{
				if (numberIsNullCaption == null)
				{
					return (Resources.Captions.NumberIsNull);
				}
				else
				{
					return (numberIsNullCaption);
				}
			}

			if (Utility.IsNumeric
				(value, nullValueIsNumeric: false, spacesInBothSidesIsAllowed: false) == false)
			{
				if (numberIsNotValidCaption == null)
				{
					return (Resources.Captions.NumberIsNotValid);
				}
				else
				{
					return (numberIsNotValidCaption);
				}
			}

			System.Globalization.CultureInfo oCultureInfo =
				new System.Globalization.CultureInfo("en-US");

			oCultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";

			double dblValue =
				System.Convert.ToDouble(value, provider: oCultureInfo);

			Dtx.Globalization.Cultures enmCulture =
				Dtx.Globalization.CultureInfo.GetCurrentCulture();

			switch (enmCulture)
			{
				case Dtx.Globalization.Cultures.Farsi:
				{
					return (JustDigitsToUnicodes(dblValue.ToString(format: format)));
				}

				default:
				{
					return (dblValue.ToString(format: format));
				}
			}
		}

		public static string NumberToWord(long number)
		{
			if (number < 0)
			{
				number = -number;
			}

			return (NumberToWord(number.ToString()));
		}

		public static string NumberToWord(string number)
		{
			if (number == null)
			{
				return (string.Empty);
			}

			number = number.Replace(" ", string.Empty);

			if (number == string.Empty)
			{
				return (string.Empty);
			}

			number =
				number.Replace(",", string.Empty);

			number =
				Convert.JustUnicodesToDigits(number);

			if (Dtx.String.IsJustLong(number) == false)
			{
				return (string.Empty);
			}

			if (number.Length > 18)
			{
				return (string.Empty);
			}

			if (number == "0")
			{
				return ("صفر");
			}

			string[,] Strings = new string[10, 5];

			Strings[0, 0] = "يک";
			Strings[0, 1] = "يازده";
			Strings[0, 2] = "ده";
			Strings[0, 3] = "يکصد";

			Strings[1, 0] = "دو";
			Strings[1, 1] = "دوازده";
			Strings[1, 2] = "بيست";
			Strings[1, 3] = "دويست";

			Strings[2, 0] = "سه";
			Strings[2, 1] = "سيزده";
			Strings[2, 2] = "سی";
			Strings[2, 3] = "سيصد";

			Strings[3, 0] = "چهار";
			Strings[3, 1] = "چهارده";
			Strings[3, 2] = "چهل";
			Strings[3, 3] = "چهارصد";

			Strings[4, 0] = "پنج";
			Strings[4, 1] = "پانزده";
			Strings[4, 2] = "پنجاه";
			Strings[4, 3] = "پانصد";

			Strings[5, 0] = "شش";
			Strings[5, 1] = "شانزده";
			Strings[5, 2] = "شصت";
			Strings[5, 3] = "ششصد";

			Strings[6, 0] = "هفت";
			Strings[6, 1] = "هفده";
			Strings[6, 2] = "هفتاد";
			Strings[6, 3] = "هفتصد";

			Strings[7, 0] = "هشت";
			Strings[7, 1] = "هجده";
			Strings[7, 2] = "هشتاد";
			Strings[7, 3] = "هشتصد";

			Strings[8, 0] = "نه";
			Strings[8, 1] = "نوزده";
			Strings[8, 2] = "نود";
			Strings[8, 3] = "نهصد";

			Strings[9, 0] = "هزار";
			Strings[9, 1] = "ميليون";
			Strings[9, 2] = "ميليارد";
			Strings[9, 3] = "تريليون";
			Strings[9, 4] = "کاتريليون";

			string strNumber = number;
			string strResult = string.Empty;
			string strLastThreeDigit = string.Empty;

			int intGroupCount = 0;
			int intLastThreeDigit = 0;
			int intDigitCount = strNumber.Length;

			while (intDigitCount > 0)
			{
				if (intDigitCount <= 2)
				{
					strLastThreeDigit = strNumber.Substring(0, intDigitCount);
				}
				else
				{
					strLastThreeDigit = strNumber.Substring(intDigitCount - 3, 3);
				}

				bool blnFlag = false;
				string strSubResult = string.Empty;
				string strLastThreeDigitTemp = strLastThreeDigit;

				if (strLastThreeDigit.Length == 3)
				{
					if (System.Convert.ToInt32(strLastThreeDigit.Substring(0, 1)) > 0)
					{
						int intTemp = System.Convert.ToInt32(strLastThreeDigit.Substring(0, 1));
						strSubResult = Strings[intTemp - 1, 3];
						blnFlag = true;
					}

					strLastThreeDigit = strLastThreeDigit.Substring(1, 2);
				}

				if (strLastThreeDigit.Length == 2)
				{
					if ((strLastThreeDigit.Substring(0, 1) == "1") && (strLastThreeDigit.Substring(1, 1) != "0"))
					{
						int intTemp = System.Convert.ToInt32(strLastThreeDigit.Substring(1, 1));

						if (blnFlag)
						{
							strSubResult += " و " + Strings[intTemp - 1, 1];
						}
						else
						{
							strSubResult += " " + Strings[intTemp - 1, 1];
						}

						blnFlag = true;
						strLastThreeDigit = string.Empty;
					}
					else
					{
						if (strLastThreeDigit.Substring(0, 1) != "0")
						{
							int intTemp = System.Convert.ToInt32(strLastThreeDigit.Substring(0, 1));

							if (blnFlag)
							{
								strSubResult += " و " + Strings[intTemp - 1, 2];
							}
							else
							{
								strSubResult += " " + Strings[intTemp - 1, 2];
							}

							blnFlag = true;
						}
						strLastThreeDigit = strLastThreeDigit.Substring(1, 1);
					}
				}

				if (strLastThreeDigit.Length == 1)
				{
					if (strLastThreeDigit != "0")
					{
						int intTemp =
							System.Convert.ToInt32(strLastThreeDigit);

						if (blnFlag)
						{
							strSubResult += " و " + Strings[intTemp - 1, 0];
						}
						else
						{
							strSubResult += " " + Strings[intTemp - 1, 0];
						}
					}
				}

				strSubResult =
					strSubResult.Trim();

				if ((strSubResult.Length > 0) && (intGroupCount > 0))
				{
					strSubResult +=
						" " + Strings[9, ((intGroupCount - 1) * 10 + 1) / 10];
				}

				if ((intGroupCount > 0) && (intLastThreeDigit > 0))
				{
					strResult =
						strSubResult + " و " + strResult;
				}
				else
				{
					strResult =
						strSubResult + " " + strResult;
				}

				intGroupCount++;
				intDigitCount -= 3;

				intLastThreeDigit =
					System.Convert.ToInt32(strLastThreeDigitTemp);
			}

			strResult = strResult.Trim();

			if (strResult.Length == 0)
			{
				strResult = "صفر";
			}

			while (strResult.Contains("  "))
			{
				strResult = strResult.Replace("  ", " ");
			}

			return (strResult);
		}
	}
}
