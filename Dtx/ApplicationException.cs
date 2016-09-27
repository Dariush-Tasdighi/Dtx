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

		public override void GetObjectData
			(System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context)
		{
			base.GetObjectData(info, context);
		}
	}
}