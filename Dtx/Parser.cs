namespace Dtx
{
	public static class Parser
	{
		static Parser()
		{
		}

		public static T Parse<T>(this string data, T defaultValue = default(T))
		{
			var varType = typeof(T);

			var varParse =
				varType.GetMethod("TryParse",
				System.Reflection.BindingFlags.Public |
				System.Reflection.BindingFlags.Static, null,
				new[] { typeof(string), varType.MakeByRefType() }, null);

			if (varParse == null)
			{
				return (defaultValue);
			}
			else
			{
				var varParameters =
					new object[] { data, null };

				var varSuccess =
					(bool)varParse.Invoke(null, varParameters);

				if (varSuccess)
				{
					return ((T)varParameters[1]);
				}
				else
				{
					return (defaultValue);
				}
			}
		}
	}
}
