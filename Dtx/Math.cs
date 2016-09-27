namespace Dtx
{
	public static class Math
	{
		public static int DivRem(int a, int b, out int result)
		{
			int d = 0;

			if (b == 0)
			{
				result = 0;
			}
			else
			{
				d = a / b;
				result = a - b * d;
			}

			return (d);
		}

		public static long DivRem(long a, long b, out long result)
		{
			result = 0;
			long d = 0;

			if (b != 0)
			{
				d = a / b;
				result = a - b * d;
			}

			return (d);
		}

		public static int Mod(int numerator, int denominator)
		{
			return (GetRemainder
				(GetRemainder(numerator, denominator) + denominator, denominator));
		}

		public static long Mod(long numerator, long denominator)
		{
			return (GetRemainder
				(GetRemainder(numerator, denominator) + denominator, denominator));
		}

		public static int GetRemainder(int a, int b)
		{
			int intReminder;

			DivRem(a, b, out intReminder);

			return (intReminder);
		}

		public static long GetRemainder(long a, long b)
		{
			long lngReminder;

			DivRem(a, b, out lngReminder);

			return (lngReminder);
		}

		public static int GetQuotient(int a, int b)
		{
			int intReminder = 0;
			int intQuotient =
				DivRem(a, b, out intReminder);

			return (intQuotient);
		}

		public static long GetQuotient(long a, long b)
		{
			long lngReminder = 0;
			long lngQuotient =
				DivRem(a, b, out lngReminder);

			return (lngQuotient);
		}
	}
}
