namespace MyApplication
{
	internal static class Program
	{
		static Program()
		{
		}

		[System.STAThread]
		internal static void Main()
		{
			// **************************************************
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			// **************************************************

			// **************************************************
			MainForm frmMain = new MainForm();
			System.Windows.Forms.Application.Run(frmMain);

			if (frmMain != null)
			{
				if (frmMain.IsDisposed == false)
				{
					frmMain.Dispose();
				}

				frmMain = null;
			}
			// **************************************************
		}
	}
}
