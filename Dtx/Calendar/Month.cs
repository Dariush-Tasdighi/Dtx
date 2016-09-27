namespace Dtx.Calendar
{
	public class Month : object
	{
		static Month()
		{
		}

		// **************************************************
		private static System.Collections.Generic.List<Month> _months;

		public static System.Collections.Generic.List<Month> Months
		{
			get
			{
				if (_months == null)
				{
					_months =
						new System.Collections.Generic.List<Month>();

					for (int intIndex = 1; intIndex <= 12; intIndex++)
					{
						_months.Add(new Month(intIndex));
					}
				}

				return (_months);
			}
		}
		// **************************************************

		public Month() : base()
		{
		}

		public Month(int value) : base()
		{
			Value = value;
		}

		public int Value { get; set; }

		public string Text
		{
			get
			{
				//return (Dtx.Text.Convert.DisplayFormattedNumber(Value));

				switch (Value)
				{
					case 1:
					{
						return ("فروردين");
					}

					case 2:
					{
						return ("ارديبهشت");
					}

					case 3:
					{
						return ("خرداد");
					}

					case 4:
					{
						return ("تير");
					}

					case 5:
					{
						return ("مرداد");
					}

					case 6:
					{
						return ("شهريور");
					}

					case 7:
					{
						return ("مهر");
					}

					case 8:
					{
						return ("آبان");
					}

					case 9:
					{
						return ("آذر");
					}

					case 10:
					{
						return ("دی");
					}

					case 11:
					{
						return ("بهمن");
					}

					case 12:
					{
						return ("اسفند");
					}

					default:
					{
						return (string.Empty);
					}
				}
			}
		}
	}
}
