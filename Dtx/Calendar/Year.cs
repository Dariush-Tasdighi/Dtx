namespace Dtx.Calendar
{
	public class Year : object
	{
		static Year()
		{
		}

		// **************************************************
		private static System.Collections.Generic.List<Year> _years;

		public static System.Collections.Generic.List<Year> Years
		{
			get
			{
				if (_years == null)
				{
					_years =
						new System.Collections.Generic.List<Year>();

					for (int intIndex = 1395; intIndex >= 1300; intIndex--)
					{
						_years.Add(new Year(intIndex));
					}
				}

				return (_years);
			}
		}
		// **************************************************

		public Year() : base()
		{
		}

		public Year(int value) : base()
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
