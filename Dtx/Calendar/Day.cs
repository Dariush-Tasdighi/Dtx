namespace Dtx.Calendar
{
	public class Day : object
	{
		static Day()
		{
		}

		// **************************************************
		private static System.Collections.Generic.List<Day> _days;

		public static System.Collections.Generic.List<Day> Days
		{
			get
			{
				if (_days == null)
				{
					_days =
						new System.Collections.Generic.List<Day>();

					for (int intIndex = 1; intIndex <= 31; intIndex++)
					{
						_days.Add(new Day(intIndex));
					}
				}

				return (_days);
			}
		}
		// **************************************************

		public Day()
			: base()
		{
		}

		public Day(int value)
			: base()
		{
			Value = value;
		}

		public int Value { get; set; }

		public string Text
		{
			get
			{
				return (Dtx.Text.Convert.ToNumberByCulture(Value));
			}
		}
	}
}
