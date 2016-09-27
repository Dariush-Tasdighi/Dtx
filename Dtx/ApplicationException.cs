namespace Dtx
{
	[System.Serializable]
	public class ApplicationException : System.ApplicationException
	{
		public ApplicationException(string message)
			: base(message)
		{
		}

		public ApplicationException(string message, int number)
			: base(message)
		{
			Number = number;
		}

		public int Number { get; protected set; }
	}
}