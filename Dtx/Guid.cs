namespace Dtx
{
	public static class Guid
	{
		static Guid()
		{
		}

		public static string NewGuid
		{
			get
			{
				return (System.Guid.NewGuid().ToString());
			}
		}

		public static string NewGuidWithoutDash
		{
			get
			{
				return (NewGuid.Replace("-", string.Empty));
			}
		}
	}
}
