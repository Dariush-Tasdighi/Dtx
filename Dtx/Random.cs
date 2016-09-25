namespace Dtx
{
	public static class Random
	{
		static Random()
		{
		}

		public static string GetRandomString
			(int length, Enums.TextCases textCase = Enums.TextCases.Normal)
		{
			string strResult = string.Empty;

			string strGuid =
				Guid.NewGuidWithoutDash;

			int intGuidLength = strGuid.Length;

			System.Text.StringBuilder oText =
				new System.Text.StringBuilder(capacity: length);

			System.Random oRandom =
				new System.Random(Seed: System.DateTime.Now.Millisecond);

			int intCount = 1;

			while (intCount <= length)
			{
				// Note: Do not write [intGuidLength - 1]!
				int intIndex =
					oRandom.Next(minValue: 0, maxValue: intGuidLength);

				oText.Append(strGuid[intIndex]);

				intCount++;
			}

			switch (textCase)
			{
				case Enums.TextCases.Normal:
				{
					strResult =
						oText.ToString();

					break;
				}

				case Enums.TextCases.LowerCase:
				{
					strResult =
						oText.ToString().ToLower();

					break;
				}

				case Enums.TextCases.UpperCase:
				{
					strResult =
						oText.ToString().ToUpper();

					break;
				}
			}

			return (strResult);
		}
	}
}
