namespace Dtx.Text
{
	public static class Utility
	{
		static Utility()
		{
		}

		/// <summary>
		/// This function never return null!
		/// This function trim the text and replace all of more than one space to one space.
		/// </summary>
		public static string FixText(string text)
		{
			if (Dtx.String.IsNullOrEmptyOrWhiteSpace(text))
			{
				return (string.Empty);
			}

			text = text.Trim();

			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}

			return (text);
		}

		public static bool IsNumeric
			(object value, bool nullValueIsNumeric = false, bool spacesInBothSidesIsAllowed = false)
		{
			if (value == null)
			{
				if (nullValueIsNumeric)
				{
					return (true);
				}
				else
				{
					return (false);
				}
			}

			if (spacesInBothSidesIsAllowed == false)
			{
				if (value.ToString().Contains(" "))
				{
					return (false);
				}
			}

			try
			{
				System.Globalization.CultureInfo oCultureInfo =
					new System.Globalization.CultureInfo("en-US");

				oCultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";

				double dbl =
					System.Convert.ToDouble(value, provider: oCultureInfo);

				return (true);
			}
			catch
			{
				return (false);
			}
		}

		public static string Encode(string text, bool convertSpace = false)
		{
			text = FixText(text);

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
			text = FixText(text);

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

		public static string FixPersianText(string text, bool convertDigits)
		{
			text = FixText(text);

			text = text.Replace("{ ", "{");
			text = text.Replace("( ", "(");
			text = text.Replace("[ ", "[");

			text = text.Replace(" }", "}");
			text = text.Replace(" )", ")");
			text = text.Replace(" ]", "]");

			text = text.Replace(" !", "!");
			text = text.Replace(" ?", "?");
			text = text.Replace(" ؟", "؟");

			text = text.Replace(" .", ".");
			text = text.Replace(" :", ":");

			text = text.Replace(" ;", ";");
			text = text.Replace(" ؛", "؛");

			text = text.Replace(" ,", ",");
			text = text.Replace(" ،", "،");

			string strTarget = string.Empty;

			char? chrNext;
			char chrCurrent;

			int intIndex = 0;
			int intNextIndex = intIndex + 1;

			while (intIndex <= text.Length - 1)
			{
				chrCurrent = text[intIndex];

				if (intIndex == text.Length - 1)
				{
					chrNext = null;
				}
				else
				{
					chrNext = text[intIndex + 1];
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
								Convert.JustDigitsToUnicodes(chrCurrent.ToString());
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
