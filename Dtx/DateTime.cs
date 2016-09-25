namespace Dtx
{
	public static class DateTime
	{
		static DateTime()
		{
		}

		public static System.DateTime MinValueForDatabase
		{
			get
			{
				return (new System.DateTime(1900, 1, 1, 12, 0, 0));
			}
		}
	}
}
