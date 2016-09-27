namespace Dtx
{
	public static class DateTime
	{
		static DateTime()
		{
		}

		/// <summary>
		/// Suitable for sql server
		/// </summary>
		public static System.DateTime MinValue
		{
			get
			{
				return (new System.DateTime(1900, 1, 1, 12, 0, 0));
			}
		}
	}
}
