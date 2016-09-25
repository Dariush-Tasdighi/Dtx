namespace Dtx.Text
{
	public static class Convert
	{
		static Convert()
		{
		}

		public static string Encode(string text)
		{
			return (Encode(text, false));
		}

		public static string Encode(string text, bool convertSpace)
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

			System.Text.StringBuilder oResult = new System.Text.StringBuilder();

			for (int intIndex = 0; intIndex <= text.Length - 1; intIndex++)
			{
				string strChar = string.Empty;
				string strNextChar = string.Empty;

				strChar = text[intIndex].ToString();

				if (intIndex < text.Length - 1)
				{
					strNextChar =
						text[intIndex + 1].ToString();
				}

				switch (strChar)
				{
					case "‌": // نيم فاصله
					{
						strChar = "&#8204;";
						break;
					}

					case "\r":
					{
						strChar = "";
						break;
					}

					case "\n":
					{
						strChar = "<br />";
						break;
					}

					case "؟":
					{
						strChar = "&#1567;";
						break;
					}

					case "،":
					{
						strChar = "&#1548;";
						break;
					}

					case "؛":
					{
						strChar = "&#1563;";
						break;
					}

					case " ":
					{
						if (convertSpace)
						{
							strChar = "&nbsp;";
						}

						break;
					}

					case "۰":
					case "0":
					{
						strChar = "&#1776;";
						break;
					}

					case "۱":
					case "1":
					{
						strChar = "&#1777;";
						break;
					}

					case "۲":
					case "2":
					{
						strChar = "&#1778;";
						break;
					}

					case "۳":
					case "3":
					{
						strChar = "&#1779;";
						break;
					}

					case "۴":
					case "4":
					{
						strChar = "&#1780;";
						break;
					}

					case "۵":
					case "5":
					{
						strChar = "&#1781;";
						break;
					}

					case "۶":
					case "6":
					{
						strChar = "&#1782;";
						break;
					}

					case "۷":
					case "7":
					{
						strChar = "&#1783;";
						break;
					}

					case "۸":
					case "8":
					{
						strChar = "&#1784;";
						break;
					}

					case "۹":
					case "9":
					{
						strChar = "&#1785;";
						break;
					}

					case "آ":
					{
						strChar = "&#1570;";
						break;
					}

					case "ا":
					{
						strChar = "&#1575;";
						break;
					}

					case "ب":
					{
						strChar = "&#1576;";
						break;
					}

					case "پ":
					{
						strChar = "&#1662;";
						break;
					}

					case "ت":
					{
						strChar = "&#1578;";
						break;
					}

					case "ث":
					{
						strChar = "&#1579;";
						break;
					}

					case "ج":
					{
						strChar = "&#1580;";
						break;
					}

					case "چ":
					{
						strChar = "&#1670;";
						break;
					}

					case "ح":
					{
						strChar = "&#1581;";
						break;
					}

					case "خ":
					{
						strChar = "&#1582;";
						break;
					}

					case "د":
					{
						strChar = "&#1583;";
						break;
					}

					case "ذ":
					{
						strChar = "&#1584;";
						break;
					}

					case "ر":
					{
						strChar = "&#1585;";
						break;
					}

					case "ز":
					{
						strChar = "&#1586;";
						break;
					}

					case "ژ":
					{
						strChar = "&#1688;";
						break;
					}

					case "س":
					{
						strChar = "&#1587;";
						break;
					}

					case "ش":
					{
						strChar = "&#1588;";
						break;
					}

					case "ص":
					{
						strChar = "&#1589;";
						break;
					}

					case "ض":
					{
						strChar = "&#1590;";
						break;
					}

					case "ط":
					{
						strChar = "&#1591;";
						break;
					}

					case "ظ":
					{
						strChar = "&#1592;";
						break;
					}

					case "ع":
					{
						strChar = "&#1593;";
						break;
					}

					case "غ":
					{
						strChar = "&#1594;";
						break;
					}

					case "ف":
					{
						strChar = "&#1601;";
						break;
					}

					case "ق":
					{
						strChar = "&#1602;";
						break;
					}

					case "ک":
					case "ك":
					{
						strChar = "&#1705;";
						break;
					}

					case "گ":
					{
						strChar = "&#1711;";
						break;
					}

					case "ل":
					{
						strChar = "&#1604;";
						break;
					}

					case "م":
					{
						strChar = "&#1605;";
						break;
					}

					case "ن":
					{
						strChar = "&#1606;";
						break;
					}

					case "و":
					{
						strChar = "&#1608;";
						break;
					}

					case "ه":
					{
						strChar = "&#1607;";
						break;
					}

					case "ی":
					case "ي":
					{
						if ((string.IsNullOrEmpty(strNextChar)) || (strNextChar == " "))
						{
							strChar = "&#1740;";
						}
						else
						{
							string str = @"÷×`~1!2@3#4$5%6^7&8*9(0)-_=+،؛,[]<.>/؟\{}|ـ«»:abcdefghijklmnopqrstuvwxyz۹۸۷۶۵۴۳۲۱۰" + "‌"; // نيم فاصله;

							str = str.ToUpper();

							if (str.Contains(strNextChar.ToUpper()))
							{
								strChar = "&#1740;";
							}
							else
							{
								strChar = "&#1610;";
							}
						}

						break;
					}

					case "ء":
					{
						strChar = "&#1569;";
						break;
					}

					case "ئ":
					{
						strChar = "&#1574;";
						break;
					}
				}

				oResult.Append(strChar);
			}

			return (oResult.ToString());
		}

		public static string Decode(string text)
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

			text = text.Replace("&#8204;", "‌");
			text = text.Replace("&#1567;", "؟");
			text = text.Replace("&#1548;", "،");
			text = text.Replace("&#1563;", "؛");
			text = text.Replace("&nbsp;", " ");
			text = text.Replace("&#1776;", "0");
			text = text.Replace("&#1777;", "1");
			text = text.Replace("&#1778;", "2");
			text = text.Replace("&#1779;", "3");
			text = text.Replace("&#1780;", "4");
			text = text.Replace("&#1781;", "5");
			text = text.Replace("&#1782;", "6");
			text = text.Replace("&#1783;", "7");
			text = text.Replace("&#1784;", "8");
			text = text.Replace("&#1785;", "9");
			text = text.Replace("&#1570;", "آ");
			text = text.Replace("&#1575;", "ا");
			text = text.Replace("&#1576;", "ب");
			text = text.Replace("&#1662;", "پ");
			text = text.Replace("&#1578;", "ت");
			text = text.Replace("&#1579;", "ث");
			text = text.Replace("&#1580;", "ج");
			text = text.Replace("&#1670;", "چ");
			text = text.Replace("&#1581;", "ح");
			text = text.Replace("&#1582;", "خ");
			text = text.Replace("&#1583;", "د");
			text = text.Replace("&#1584;", "ذ");
			text = text.Replace("&#1585;", "ر");
			text = text.Replace("&#1586;", "ز");
			text = text.Replace("&#1688;", "ژ");
			text = text.Replace("&#1587;", "س");
			text = text.Replace("&#1588;", "ش");
			text = text.Replace("&#1589;", "ص");
			text = text.Replace("&#1590;", "ض");
			text = text.Replace("&#1591;", "ط");
			text = text.Replace("&#1592;", "ظ");
			text = text.Replace("&#1593;", "ع");
			text = text.Replace("&#1594;", "غ");
			text = text.Replace("&#1601;", "ف");
			text = text.Replace("&#1602;", "ق");
			text = text.Replace("&#1705;", "ک");
			text = text.Replace("&#1711;", "گ");
			text = text.Replace("&#1604;", "ل");
			text = text.Replace("&#1605;", "م");
			text = text.Replace("&#1606;", "ن");
			text = text.Replace("&#1608;", "و");
			text = text.Replace("&#1607;", "ه");
			text = text.Replace("&#1610;", "ي");
			text = text.Replace("&#1740;", "ي");
			text = text.Replace("&#1569;", "ء");
			text = text.Replace("&#1574;", "ئ");

			text = text.Replace("<br>", System.Environment.NewLine);
			text = text.Replace("<br/>", System.Environment.NewLine);
			text = text.Replace("<br />", System.Environment.NewLine);

			return (text);
		}

		public static string DatabaseToShow(long number)
		{
			return (DatabaseToShow(number.ToString()));
		}

		public static string DatabaseToShow(string text)
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
			if (text == null)
			{
				return (string.Empty);
			}

			text = text.Trim();

			if (text == string.Empty)
			{
				return (string.Empty);
			}

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

		public static string UnicodeToDigits(string number)
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

		public static string DisplayNumber(long? number)
		{
			if (number.HasValue == false)
			{
				return (string.Empty);
			}

			string strNumber = number.Value.ToString();

			Dtx.Globalization.Cultures enmCulture =
				Dtx.Globalization.CultureInfo.GetCurrentCulture();

			switch (enmCulture)
			{
				case Dtx.Globalization.Cultures.Farsi:
				{
					return (DigitsToUnicode(strNumber));
				}

				default:
				{
					return (strNumber);
				}
			}
		}

		public static string DisplayNumber(string number)
		{
			if (string.IsNullOrWhiteSpace(number))
			{
				return (string.Empty);
			}

			Dtx.Globalization.Cultures enmCulture =
				Dtx.Globalization.CultureInfo.GetCurrentCulture();

			switch (enmCulture)
			{
				case Dtx.Globalization.Cultures.Farsi:
				{
					return (DigitsToUnicode(number));
				}

				default:
				{
					return (number);
				}
			}
		}

		public static string DisplayFormattedNumber(object number)
		{
			if (number == null)
			{
				return (string.Empty);
			}

			long lngNumber = 0;

			try
			{
				lngNumber =
					System.Convert.ToInt64(number);
			}
			catch (System.Exception)
			{
				return (string.Empty);
			}

			string strNumber = lngNumber.ToString("#,##0");

			Dtx.Globalization.Cultures enmCulture =
				Dtx.Globalization.CultureInfo.GetCurrentCulture();

			switch (enmCulture)
			{
				case Dtx.Globalization.Cultures.Farsi:
				{
					return (DigitsToUnicode(strNumber));
				}

				default:
				{
					return (strNumber);
				}
			}
		}

		public static string DigitsToUnicode(long? number)
		{
			if (number.HasValue == false)
			{
				return ("-----");
			}
			else
			{
				return (DigitsToUnicode(number.ToString()));
			}
		}

		public static string DigitsToUnicode(string number)
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

			number = number.Replace(",", string.Empty);
			number = Convert.UnicodeToDigits(number);

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
						int intTemp = System.Convert.ToInt32(strLastThreeDigit);

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

				strSubResult = strSubResult.Trim();

				if ((strSubResult.Length > 0) && (intGroupCount > 0))
				{
					strSubResult += " " + Strings[9, ((intGroupCount - 1) * 10 + 1) / 10];
				}

				if ((intGroupCount > 0) && (intLastThreeDigit > 0))
				{
					strResult = strSubResult + " و " + strResult;
				}
				else
				{
					strResult = strSubResult + " " + strResult;
				}

				intGroupCount++;
				intDigitCount -= 3;
				intLastThreeDigit = System.Convert.ToInt32(strLastThreeDigitTemp);
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

		public static string PdfToText1(string source)
		{
			if (string.IsNullOrEmpty(source))
			{
				return (string.Empty);
			}

			source = source.Trim();
			if (source == string.Empty)
			{
				return (string.Empty);
			}

			//while (source.IndexOf("  ") >= 0)
			//{
			//    source = source.Replace("  ", " ");
			//}

			string strLineTarget = string.Empty;
			string strTextTarget = string.Empty;

			char? chrNext = null;
			char? chrPrevious = null;

			char chrCurrent = '\0';

			int intIndex = source.Length - 1;
			while (intIndex >= 0)
			{
				if (string.IsNullOrEmpty(strLineTarget))
				{
					chrPrevious = null;
				}
				else
				{
					chrPrevious =
						System.Convert.ToChar(strLineTarget.Substring(strLineTarget.Length - 1));
				}

				chrCurrent = source[intIndex];
				int intCurrent = System.Convert.ToInt32(chrCurrent);

				if (intIndex == 0)
				{
					chrNext = null;
				}
				else
				{
					chrNext = source[intIndex - 1];
				}

				switch (intCurrent)
				{
					// ظاهرا قبلا غ بوده است
					case 2:
					{
						strLineTarget += 'ک'.ToString();
						break;
					}

					case 3:
					{
						// اينکه قبلش فاصله بوده و بايد ف باشد تست شده است
						if (chrPrevious == 32)
						{
							strLineTarget += 'ف'.ToString();
						}
						else
						{
							// آخری نيم فاصله است
							if ((chrPrevious.HasValue == false) || (chrPrevious == 64) || (chrPrevious == '‌'))
							{
								strLineTarget += 'ک'.ToString();
							}
							else
							{
								strLineTarget += 'ف'.ToString();
							}
						}
						break;
					}

					case 4:
					{
						// آخری نيم فاصله است
						if ((chrPrevious.HasValue == false) || (chrPrevious == 32) || (chrPrevious == 64) || (chrPrevious == '‌'))
						{
							strLineTarget += 'ک'.ToString();
						}
						else
						{
							strLineTarget += 'ظ'.ToString();
						}
						break;
					}

					case 5:
					{
						strLineTarget += 'ف'.ToString();
						break;
					}

					case 6:
					{
						if (chrPrevious == 32)
						{
							strLineTarget += 'ن'.ToString();
						}
						else
						{
							// آخری نيم فاصله است
							if ((chrPrevious.HasValue == false) || (chrPrevious == 64) || (chrPrevious == '‌'))
							{
								strLineTarget += 'ن'.ToString();
							}
							else
							{
								strLineTarget += 'ق'.ToString();
							}
						}
						break;
					}

					case 8:
					{
						strLineTarget += 'ف'.ToString();
						break;
					}

					case 9:
					{
						strLineTarget += 'ن'.ToString();
						break;
					}

					// ظاهرا ن هم بوده چک شود
					// بعد هم ظاهرا ظ بود تست شود
					case 10:
					{
						if ((chrNext.HasValue == false) || (chrNext != System.Convert.ToChar(13)))
						{
							strLineTarget += 'ن'.ToString();
						}
						else
						{
							if (string.IsNullOrEmpty(strTextTarget))
							{
								strTextTarget += strLineTarget;
							}
							else
							{
								strTextTarget = strLineTarget + strTextTarget;
								//strTextTarget = strLineTarget + System.Environment.NewLine + strTextTarget;
							}

							strLineTarget = string.Empty;
						}
						break;
					}

					case 11:
					{
						// اينکه قبلش فاصله بوده و بايد ق باشد تست شده است
						if (chrPrevious == 32)
						{
							strLineTarget += 'ق'.ToString();
						}
						else
						{
							strLineTarget += 'ف'.ToString();
						}
						break;
					}

					// ظاهرا قبلا ق بوده است
					case 12:
					{
						// آخری نيم فاصله است
						if ((chrPrevious.HasValue == false) || (chrPrevious == 32) || (chrPrevious == 64) || (chrPrevious == '‌'))
						{
							strLineTarget += 'ف'.ToString();
							strLineTarget += "‌"; // نيم فاصله
						}
						else
						{
							strLineTarget += 'ق'.ToString();
						}
						break;
					}

					case 13:
					{
						if (chrPrevious.HasValue == false)
						{
							strLineTarget += 'ط'.ToString();
						}
						else
						{
							if (chrPrevious.Value == 10)
							{
							}
							else
							{
								strLineTarget += 'ط'.ToString();
							}
						}
						break;
					}

					case 14:
					{
						strLineTarget += 'ط'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 15:
					{
						strLineTarget += 'ط'.ToString();
						break;
					}

					case 16:
					{
						strLineTarget += 'ع'.ToString();
						break;
					}

					case 17:
					{
						strLineTarget += 'ض'.ToString();
						break;
					}

					case 18:
					{
						strLineTarget += 'ع'.ToString();
						break;
					}

					case 19:
					{
						strLineTarget += 'ط'.ToString();
						break;
					}

					case 21:
					{
						strLineTarget += 'غ'.ToString();
						break;
					}

					case 22:
					{
						strLineTarget += 'ق'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 24:
					{
						strLineTarget += 'ف'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 32:
					{
						strLineTarget += ' '.ToString();
						break;
					}

					case 44:
					{
						strLineTarget += '،'.ToString();
						break;
					}

					case 45:
					{
						strLineTarget += '-'.ToString();
						break;
					}

					case 47:
					{
						strLineTarget += '.'.ToString();
						break;
					}

					case 58:
					{
						strLineTarget += ':'.ToString();
						break;
					}

					case 59:
					{
						strLineTarget += ';'.ToString();
						break;
					}

					case 60:
					{
						strLineTarget += '»'.ToString();
						break;
					}

					case 62:
					{
						strLineTarget += '«'.ToString();
						break;
					}

					// ظاهرا گاف نيست دقت شود
					// احتمالا حروف اضافه مثل کسره و ضمه و اينهاست
					case 64:
					{
						//strLineTarget += 'گ'.ToString();
						strTextTarget = strLineTarget + System.Environment.NewLine + strTextTarget;
						break;
					}

					case 65:
					{
						strLineTarget += 'ا'.ToString();
						break;
					}

					case 66:
					{
						strLineTarget += 'ا'.ToString();
						break;
					}

					case 67:
					{
						strLineTarget += 'آ'.ToString();
						break;
					}

					case 70:
					{
						strLineTarget += 'أ'.ToString();
						break;
					}

					// ان مثل تقریبا
					case 72:
					{
						strLineTarget += 'ا'.ToString();
						break;
					}

					case 74:
					{
						strLineTarget += 'ب'.ToString();
						break;
					}

					case 75:
					{
						strLineTarget += 'ب'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 76:
					{
						strLineTarget += 'ب'.ToString();
						break;
					}

					case 77:
					{
						strLineTarget += 'ب'.ToString();
						break;
					}

					case 78:
					{
						strLineTarget += 'پ'.ToString();
						break;
					}

					case 80:
					{
						strLineTarget += 'پ'.ToString();
						break;
					}

					case 81:
					{
						strLineTarget += 'پ'.ToString();
						break;
					}

					case 83:
					{
						strLineTarget += 'ت'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 84:
					{
						strLineTarget += 'ت'.ToString();
						break;
					}

					case 85:
					{
						strLineTarget += 'ت'.ToString();
						break;
					}

					case 89:
					{
						strLineTarget += 'ث'.ToString();
						break;
					}

					case 92:
					{
						strLineTarget += 'ج'.ToString();
						break;
					}

					case 93:
					{
						strLineTarget += 'ج'.ToString();
						break;
					}

					case 95:
					{
						strLineTarget += 'چ'.ToString();
						break;
					}

					case 96:
					{
						strLineTarget += 'چ'.ToString();
						break;
					}

					case 97:
					{
						strLineTarget += 'چ'.ToString();
						break;
					}

					case 99:
					{
						strLineTarget += 'ح'.ToString();
						break;
					}

					case 100:
					{
						strLineTarget += 'ح'.ToString();
						break;
					}

					case 101:
					{
						strLineTarget += 'ح'.ToString();
						break;
					}

					case 103:
					{
						strLineTarget += 'خ'.ToString();
						break;
					}

					case 104:
					{
						strLineTarget += 'خ'.ToString();
						break;
					}

					case 105:
					{
						strLineTarget += 'خ'.ToString();
						break;
					}

					case 106:
					{
						strLineTarget += 'د'.ToString();
						break;
					}

					case 107:
					{
						strLineTarget += 'د'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 108:
					{
						strLineTarget += 'ذ'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 109:
					{
						strLineTarget += 'ذ'.ToString();
						break;
					}

					case 110:
					{
						strLineTarget += 'ر'.ToString();
						break;
					}

					case 111:
					{
						strLineTarget += 'ر'.ToString();
						break;
					}

					case 112:
					{
						strLineTarget += 'ز'.ToString();
						break;
					}

					case 113:
					{
						strLineTarget += 'ز'.ToString();
						break;
					}

					case 116:
					{
						strLineTarget += 'س'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 117:
					{
						strLineTarget += 'س'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 118:
					{
						strLineTarget += 'س'.ToString();
						break;
					}

					case 119:
					{
						strLineTarget += 'س'.ToString();
						break;
					}

					case 120:
					{
						strLineTarget += 'ش'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 121:
					{
						strLineTarget += 'ش'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 122:
					{
						strLineTarget += 'ش'.ToString();
						break;
					}

					case 123:
					{
						strLineTarget += 'ش'.ToString();
						break;
					}

					case 126:
					{
						strLineTarget += 'ص'.ToString();
						break;
					}

					case 162:
					{
						strLineTarget += 'گ'.ToString();
						break;
					}

					case 163:
					{
						strLineTarget += 'گ'.ToString();
						break;
					}

					case 164:
					{
						strLineTarget += 'ل'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 165:
					{
						strLineTarget += 'ل'.ToString();
						break;
					}

					case 166:
					{
						strLineTarget += 'ل'.ToString();
						break;
					}

					case 167:
					{
						strLineTarget += 'ل'.ToString();
						break;
					}

					case 168:
					{
						strLineTarget += 'م'.ToString();
						break;
					}

					case 169:
					{
						strLineTarget += 'م'.ToString();
						break;
					}

					case 170:
					{
						strLineTarget += 'م'.ToString();
						break;
					}

					case 171:
					{
						strLineTarget += 'م'.ToString();
						break;
					}

					case 172:
					{
						strLineTarget += 'ن'.ToString();
						break;
					}

					case 174:
					{
						strLineTarget += 'ن'.ToString();
						break;
					}

					case 175:
					{
						strLineTarget += 'ن'.ToString();
						break;
					}

					case 176:
					{
						strLineTarget += 'و'.ToString();
						break;
					}

					case 177:
					{
						strLineTarget += 'و'.ToString();
						break;
					}

					case 178:
					{
						strLineTarget += 'ه'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 179:
					{
						strLineTarget += 'ه'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 180:
					{
						strLineTarget += 'ه'.ToString();
						break;
					}

					// همه(ی) دقت شود
					case 182:
					{
						strLineTarget += 'ه'.ToString();
						break;
					}

					// همه(ی) دقت شود
					// تاييد شد
					case 183:
					{
						strLineTarget += 'ه'.ToString();
						break;
					}

					case 186:
					{
						strLineTarget += 'ی'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 187:
					{
						strLineTarget += 'ی'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 188:
					{
						strLineTarget += 'ی'.ToString();
						break;
					}

					case 189:
					{
						strLineTarget += 'ی'.ToString();
						break;
					}

					// ظاهرا قبلا لام خالی بوده
					case 191:
					{
						strLineTarget += "لا";
						break;
					}

					// ظاهرا قبلا لام خالی بوده
					case 192:
					{
						strLineTarget += "لا";
						break;
					}

					// ?????
					case 199:
					{
						break;
					}

					case 210:
					{
						strLineTarget += 'ه'.ToString();
						break;
					}

					// کسره
					case 223:
					{
						break;
					}

					case 230:
					{
						strLineTarget += 'ص'.ToString();
						break;
					}

					case 233:
					{
						strLineTarget += 'ع'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 237:
					{
						strLineTarget += 'ع'.ToString();
						break;
					}

					case 238:
					{
						strLineTarget += 'ع'.ToString();
						break;
					}

					case 240:
					{
						strLineTarget += 'ک'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 241:
					{
						strLineTarget += 'ک'.ToString();
						break;
					}

					case 242:
					{
						strLineTarget += 'گ'.ToString();
						break;
					}

					case 956:
					{
						strLineTarget += 'ه'.ToString();
						break;
					}

					default:
					{
						switch (chrCurrent)
						{
							case 'X':
							{
								strLineTarget += 'ث'.ToString();
								break;
							}

							case 'r':
							{
								strLineTarget += 'ژ'.ToString();
								break;
							}

							case '£':
							{
								strLineTarget += 'س'.ToString();
								break;
							}

							case '':
							{
								strLineTarget += 'ظ'.ToString();
								break;
							}

							case '¡':
							{
								strLineTarget += 'گ'.ToString();
								break;
							}

							case '«':
							{
								strLineTarget += 'م'.ToString();
								break;
							}

							default:
							{
								strLineTarget += chrCurrent.ToString();
								break;
							}
						}

						break;
					}
				}

				intIndex--;
				//intIndex++;
			}

			if (string.IsNullOrEmpty(strTextTarget))
			{
				strTextTarget += strLineTarget;
			}
			else
			{
				strTextTarget = strLineTarget + strTextTarget;
				//strTextTarget = strLineTarget + System.Environment.NewLine + strTextTarget;
			}

			while (strTextTarget.IndexOf("  ") >= 0)
			{
				strTextTarget = strTextTarget.Replace("  ", " ");
			}

			return (strTextTarget);
		}

		public static string PdfToText2(string source)
		{
			if (string.IsNullOrEmpty(source))
			{
				return (string.Empty);
			}

			//source = source.Trim();
			//if (source == string.Empty)
			//{
			//    return (string.Empty);
			//}

			//while (source.IndexOf("  ") >= 0)
			//{
			//    source = source.Replace("  ", " ");
			//}

			string strLineTarget = string.Empty;
			string strTextTarget = string.Empty;

			char? chrNext = null;
			char? chrPrevious = null;

			char chrCurrent = '\0';

			int intIndex = source.Length - 1;
			while (intIndex >= 0)
			{
				if (string.IsNullOrEmpty(strLineTarget))
				{
					chrPrevious = null;
				}
				else
				{
					chrPrevious =
						System.Convert.ToChar(strLineTarget.Substring(strLineTarget.Length - 1));
				}

				chrCurrent = source[intIndex];
				int intCurrent = System.Convert.ToInt32(chrCurrent);

				if (intIndex == 0)
				{
					chrNext = null;
				}
				else
				{
					chrNext = source[intIndex - 1];
				}

				switch (intCurrent)
				{
					case 1:
					{
						strLineTarget += 'ن'.ToString();
						break;
					}

					// ی اول و وسط
					case 2:
					{
						strLineTarget += 'ي'.ToString();
						break;
					}

					case 3:
					{
						strLineTarget += 'د'.ToString();
						break;
					}

					case 4:
					{
						strLineTarget += 'ب'.ToString();
						break;
					}

					case 5:
					{
						strLineTarget += ' '.ToString();
						break;
					}

					case 6:
					{
						strLineTarget += 'و'.ToString();
						break;
					}

					// زنجير = ي
					case 7:
					{
						strLineTarget += 'ي'.ToString();
						break;
					}

					case 8:
					{
						strLineTarget += 'م'.ToString();
						break;
					}

					case 9:
					{
						strLineTarget += 'د'.ToString();
						break;
					}

					case 10:
					{
						strLineTarget += 'ر'.ToString();
						break;
					}

					case 11:
					{
						strLineTarget += 'ح'.ToString();
						break;
					}

					// ی تنها يا آخر
					case 12:
					{
						strLineTarget += 'ی'.ToString();
						break;
					}

					case 13:
					{
						strLineTarget += 'ا'.ToString();
						break;
					}

					case 14:
					{
						strLineTarget += 'ج'.ToString();
						break;
					}

					// ه آخر
					case 15:
					{
						strLineTarget += 'ه'.ToString();
						break;
					}

					case 16:
					{
						strLineTarget += 'ا'.ToString();
						break;
					}

					// از
					// زنجير
					case 17:
					{
						strLineTarget += 'ز'.ToString();
						break;
					}

					case 18:
					{
						strLineTarget += 'آ'.ToString();
						break;
					}

					case 19:
					{
						strLineTarget += 'و'.ToString();
						break;
					}

					case 20:
					{
						strLineTarget += 'ت'.ToString();
						break;
					}

					case 21:
					{
						strLineTarget += '،'.ToString();
						break;
					}

					case 23:
					{
						strLineTarget += 'خ'.ToString();
						break;
					}

					case 24:
					{
						strLineTarget += 'س'.ToString();
						break;
					}

					case 25:
					{
						strLineTarget += 'م'.ToString();
						break;
					}

					case 26:
					{
						strLineTarget += 'ب'.ToString();
						break;
					}

					case 27:
					{
						strLineTarget += 'ل'.ToString();
						break;
					}

					case 28:
					{
						strLineTarget += 'ک'.ToString();
						break;
					}

					case 29:
					{
						strLineTarget += 'ه'.ToString();
						break;
					}

					case 30:
					{
						strLineTarget += 'گ'.ToString();
						break;
					}

					case 31:
					{
						strLineTarget += 'ن'.ToString();
						break;
					}

					// 
					case 32:
					{
						strLineTarget += ' '.ToString();
						break;
					}

					// جنبش
					case 33:
					{
						strLineTarget += 'ش'.ToString();
						break;
					}

					case 34:
					{
						strLineTarget += 'ن'.ToString();
						break;
					}

					// ش اول
					case 35:
					{
						strLineTarget += 'ش'.ToString();
						break;
					}

					// گفتم
					case 36:
					{
						strLineTarget += 'ت'.ToString();
						break;
					}

					// گفتم
					case 37:
					{
						strLineTarget += 'ف'.ToString();
						break;
					}

					// گفتم
					// گ
					// شنفتم
					// ف
					case 38:
					{
						strLineTarget += 'گ'.ToString();
						break;
					}

					// زنجير = ر
					case 39:
					{
						strLineTarget += 'ر'.ToString();
						break;
					}

					// حس
					case 41:
					{
						strLineTarget += 'ح'.ToString();
						break;
					}

					case 42:
					{
						strLineTarget += 'ش'.ToString();
						break;
					}

					case 43:
					{
						strLineTarget += 'م'.ToString();
						break;
					}

					case 44:
					{
						strLineTarget += 'ه'.ToString();
						break;
					}

					case 45:
					{
						strLineTarget += 'ف'.ToString();
						break;
					}

					case 46:
					{
						strLineTarget += '.'.ToString();
						break;
					}

					// بيزارم = ز
					case 47:
					{
						strLineTarget += 'ز'.ToString();
						break;
					}

					case 48:
					{
						strLineTarget += 'ک'.ToString();
						break;
					}

					// زنجير = ج
					case 49:
					{
						strLineTarget += 'ج'.ToString();
						break;
					}

					case 52:
					{
						strLineTarget += 'چ'.ToString();
						break;
					}

					case 54:
					{
						strLineTarget += 'خ'.ToString();
						break;
					}

					case 60:
					{
						strLineTarget += 'ع'.ToString();
						break;
					}

					case 66:
					{
						strLineTarget += 'ض'.ToString();
						break;
					}

					case 67:
					{
						strLineTarget += 'ص'.ToString();
						break;
					}

					case 72:
					{
						strLineTarget += 'غ'.ToString();
						break;
					}

					case 73:
					{
						strLineTarget += 'ظ'.ToString();
						break;
					}

					default:
					{
						strLineTarget += chrCurrent.ToString();
						break;
					}
				}

				intIndex--;
			}

			if (string.IsNullOrEmpty(strTextTarget))
			{
				strTextTarget += strLineTarget;
			}
			else
			{
				strTextTarget = strLineTarget + strTextTarget;
				//strTextTarget = strLineTarget + System.Environment.NewLine + strTextTarget;
			}

			while (strTextTarget.IndexOf("  ") >= 0)
			{
				strTextTarget = strTextTarget.Replace("  ", " ");
			}

			return (strTextTarget);
		}

		public static string PdfToText3(string source)
		{
			if (string.IsNullOrEmpty(source))
			{
				return (string.Empty);
			}

			//source = source.Trim();
			//if (source == string.Empty)
			//{
			//    return (string.Empty);
			//}

			//while (source.IndexOf("  ") >= 0)
			//{
			//    source = source.Replace("  ", " ");
			//}

			string strLineTarget = string.Empty;
			string strTextTarget = string.Empty;

			char? chrNext = null;
			char? chrPrevious = null;

			char chrCurrent = '\0';

			int intIndex = source.Length - 1;
			while (intIndex >= 0)
			{
				if (string.IsNullOrEmpty(strLineTarget))
				{
					chrPrevious = null;
				}
				else
				{
					chrPrevious =
						System.Convert.ToChar(strLineTarget.Substring(strLineTarget.Length - 1));
				}

				chrCurrent = source[intIndex];
				int intCurrent = System.Convert.ToInt32(chrCurrent);

				if (intIndex == 0)
				{
					chrNext = null;
				}
				else
				{
					chrNext = source[intIndex - 1];
				}

				switch (intCurrent)
				{
					case 1:
					{
						strLineTarget += 'ت'.ToString();
						break;
					}

					// زوايا
					case 2:
					{
						strLineTarget += 'ي'.ToString();
						break;
					}

					case 3:
					{
						strLineTarget += 'ر'.ToString();
						break;
					}

					// گرديده
					case 4:
					{
						strLineTarget += 'د'.ToString();
						break;
					}

					case 5:
					{
						strLineTarget += 'م'.ToString();
						break;
					}

					// قبلا ن
					case 6:
					{
						// نيم فاصله
						if ((chrPrevious == '‌') || (chrPrevious == '،'))
						{
							strLineTarget += 'ب'.ToString();
						}
						else
						{
							strLineTarget += ' '.ToString();
						}
						break;
					}

					case 8:
					{
						strLineTarget += 'ن'.ToString();
						break;
					}

					case 9:
					{
						strLineTarget += 'ا'.ToString();
						break;
					}

					case 10:
					{
						strLineTarget += 'د'.ToString();
						break;
					}

					case 11:
					{
						strLineTarget += '،'.ToString();
						break;
					}

					case 13:
					{
						strLineTarget += 'ا'.ToString();
						break;
					}

					case 14:
					{
						strLineTarget += 'س'.ToString();
						break;
					}

					// گرديده
					case 17:
					{
						strLineTarget += 'ه'.ToString();
						break;
					}

					case 18:
					{
						strLineTarget += 'ر'.ToString();
						break;
					}

					// عمل
					case 19:
					{
						strLineTarget += 'م'.ToString();
						break;
					}

					case 20:
					{
						strLineTarget += 'ش'.ToString();
						break;
					}

					case 23:
					{
						strLineTarget += 'ز'.ToString();
						break;
					}

					// مفاهيم
					case 24:
					{
						strLineTarget += 'ي'.ToString();
						break;
					}

					case 25:
					{
						strLineTarget += 'پ'.ToString();
						break;
					}

					case 30:
					{
						strLineTarget += 'ع'.ToString();
						break;
					}

					case 31:
					{
						strLineTarget += 'ح'.ToString();
						break;
					}

					case 32:
					{
						strLineTarget += 'ف'.ToString();
						break;
					}

					case 34:
					{
						strLineTarget += 'ز'.ToString();
						break;
					}

					case 36:
					{
						strLineTarget += 'ت'.ToString();
						break;
					}

					// انتزاعی
					case 40:
					{
						strLineTarget += 'ی'.ToString();
						break;
					}

					case 41:
					{
						strLineTarget += 'ع'.ToString();
						break;
					}

					// قبلا ت
					case 42:
					{
						strLineTarget += 'ن'.ToString();
						break;
					}

					case 43:
					{
						strLineTarget += 'و'.ToString();
						break;
					}

					// گرديده
					case 44:
					{
						strLineTarget += 'گ'.ToString();
						break;
					}

					case 46:
					{
						strLineTarget += 'آ'.ToString();
						break;
					}

					case 50:
					{
						strLineTarget += 'ن'.ToString();
						break;
					}

					// قبلا ب
					case 52:
					{
						strLineTarget += 'ه'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					case 53:
					{
						strLineTarget += 'س'.ToString();
						break;
					}

					// رفتار
					case 57:
					{
						strLineTarget += 'ف'.ToString();
						break;
					}

					case 63:
					{
						strLineTarget += 'ب'.ToString();
						break;
					}

					case 64:
					{
						strLineTarget += 'و'.ToString();
						break;
					}

					case 68:
					{
						strLineTarget += 'ش'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					// مفاهيم
					case 69:
					{
						strLineTarget += 'ه'.ToString();
						break;
					}

					case 71:
					{
						strLineTarget += 'ع'.ToString();
						break;
					}

					case 73:
					{
						strLineTarget += 'خ'.ToString();
						break;
					}

					// مظاهری
					case 74:
					{
						strLineTarget += 'ی'.ToString();
						strLineTarget += "‌"; // نيم فاصله
						break;
					}

					// قبلا ن
					// شناخت
					// ظاهرا کشيده
					case 75:
					{
						//strLineTarget += 'ن'.ToString();
						break;
					}

					case 79:
					{
						strLineTarget += 'ک'.ToString();
						break;
					}

					case 83:
					{
						strLineTarget += 'ظ'.ToString();
						break;
					}

					case 84:
					{
						strLineTarget += 'ص'.ToString();
						break;
					}

					case 85:
					{
						strLineTarget += 'س'.ToString();
						break;
					}

					case 86:
					{
						strLineTarget += 'ل'.ToString();
						break;
					}

					case 88:
					{
						strLineTarget += 'ج'.ToString();
						break;
					}

					// شهودی
					case 91:
					{
						strLineTarget += 'ه'.ToString();
						break;
					}

					case 92:
					{
						strLineTarget += 'ذ'.ToString();
						break;
					}

					// احساسات
					case 95:
					{
						strLineTarget += 'ح'.ToString();
						break;
					}

					// احساسات
					case 98:
					{
						strLineTarget += 'ت'.ToString();
						break;
					}

					case 101:
					{
						strLineTarget += 'ب'.ToString();
						break;
					}

					case 109:
					{
						strLineTarget += 'ث'.ToString();
						break;
					}

					case 111:
					{
						strLineTarget += 'چ'.ToString();
						break;
					}

					// شرف
					case 133:
					{
						strLineTarget += 'ف'.ToString();
						break;
					}

					case 8216:
					{
						strLineTarget += 'م'.ToString();
						break;
					}

					case 8217:
					{
						strLineTarget += 'ت'.ToString();
						break;
					}

					default:
					{
						strLineTarget += chrCurrent.ToString();
						break;
					}
				}

				intIndex--;
			}

			if (string.IsNullOrEmpty(strTextTarget))
			{
				strTextTarget += strLineTarget;
			}
			else
			{
				strTextTarget = strLineTarget + strTextTarget;
				//strTextTarget = strLineTarget + System.Environment.NewLine + strTextTarget;
			}

			while (strTextTarget.IndexOf("  ") >= 0)
			{
				strTextTarget = strTextTarget.Replace("  ", " ");
			}

			return (strTextTarget);
		}

		/// <summary>
		/// Version: 1.0.1
		/// Update Date: 1392/06/03
		/// Developer: Mr. Dariush Tasdighi
		/// </summary>
		public static string FixPersianText(string source, bool convertDigits)
		{
			if (string.IsNullOrEmpty(source))
			{
				return (string.Empty);
			}

			source = source.Trim();
			if (source == string.Empty)
			{
				return (string.Empty);
			}

			while (source.Contains("  "))
			{
				source = source.Replace("  ", " ");
			}

			source = source.Replace("{ ", "{");
			source = source.Replace("( ", "(");
			source = source.Replace("[ ", "[");

			source = source.Replace(" }", "}");
			source = source.Replace(" )", ")");
			source = source.Replace(" ]", "]");

			source = source.Replace(" !", "!");
			source = source.Replace(" ?", "?");
			source = source.Replace(" ؟", "؟");

			source = source.Replace(" .", ".");
			source = source.Replace(" :", ":");

			source = source.Replace(" ;", ";");
			source = source.Replace(" ؛", "؛");

			source = source.Replace(" ,", ",");
			source = source.Replace(" ،", "،");

			string strTarget = string.Empty;

			char? chrNext;
			char chrCurrent;

			int intIndex = 0;
			int intNextIndex = intIndex + 1;

			while (intIndex <= source.Length - 1)
			{
				chrCurrent = source[intIndex];

				if (intIndex == source.Length - 1)
				{
					chrNext = null;
				}
				else
				{
					chrNext = source[intIndex + 1];
				}

				switch (chrCurrent)
				{
					case '{':
					case '(':
					case '[':
					{
						if ((intIndex == 0) ||
							(strTarget.Substring(strTarget.Length - 1) == " ") ||
							(strTarget.Substring(strTarget.Length - 1) == "\n") ||
							(strTarget.Substring(strTarget.Length - 1) == "\r"))
						{
							strTarget += chrCurrent.ToString();
						}
						else
						{
							strTarget += " " + chrCurrent.ToString();
						}
						break;
					}

					case 'ی':
					case 'ي':
					case 'ئ':
					{
						switch (chrNext)
						{
							case ' ':
							case '<':
							case '>':

							case '‌':
							case ')':
							case '}':
							case ']':
							case null:
							{
								strTarget += "ی";
								break;
							}

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

							case '-':
							case '=':

							case '!':
							case '@':
							case '#':
							case '$':
							case '%':
							case '^':
							case '&':
							case '*':

							case '_':
							case '+':

							case '|':
							case '؛':
							case ':':
							case '،':
							case ',':

							case '(':
							case '{':
							case '[':

							case '.':
							case '/':
							case '?':
							case '؟':
							case '"':
							case '`':
							case '~':

							case '\'':
							case '\\':
							{
								strTarget += "ی";
								//strTarget += " ";
								break;
							}

							default:
							{
								strTarget += "ي";
								break;
							}
						}
						break;
					}

					case 'ك':
					case 'ک':
					{
						strTarget += "ک";
						break;
					}

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
						if (convertDigits)
						{
							strTarget +=
								Convert.DigitsToUnicode(chrCurrent.ToString());
						}
						else
						{
							strTarget += chrCurrent.ToString();
						}
						break;
					}

					case '}':
					case ')':
					case ']':
					case '!':
					case '?':
					case '؟':
					case '.':
					case ':':
					case ';':
					case '؛':
					case ',':
					case '،':
					{
						if ((chrNext == ' ') || (chrNext == '\n') || (chrNext == '\r'))
						{
							strTarget += chrCurrent.ToString();
						}
						else
						{
							strTarget += chrCurrent.ToString() + " ";
						}
						break;
					}

					default:
					{
						strTarget += chrCurrent.ToString();
						break;
					}
				}
				intIndex++;
			}
			return (strTarget);
		}
	}
}
