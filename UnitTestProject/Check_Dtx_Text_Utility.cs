namespace UnitTestProject
{
	[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
	public class Check_Dtx_Text_Utility : object
	{
		public Check_Dtx_Text_Utility()
			: base()
		{
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod01()
		{
			string strSource = null;

			string strActual =
				Dtx.Text.Utility.FixText(text: strSource);

			string strExpected = string.Empty;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod02()
		{
			string strSource = string.Empty;

			string strActual =
				Dtx.Text.Utility.FixText(text: strSource);

			string strExpected = string.Empty;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod03()
		{
			string strSource = "            ";

			string strActual =
				Dtx.Text.Utility.FixText(text: strSource);

			string strExpected = string.Empty;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod04()
		{
			string strSource = "     Ali Reza Alavi     ";

			string strActual =
				Dtx.Text.Utility.FixText(text: strSource);

			string strExpected = "Ali Reza Alavi";

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod05()
		{
			string strSource = "     Ali  Reza  Alavi     ";

			string strActual =
				Dtx.Text.Utility.FixText(text: strSource);

			string strExpected = "Ali Reza Alavi";

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod06()
		{
			string strSource = "     Ali     Reza     Alavi     ";

			string strActual =
				Dtx.Text.Utility.FixText(text: strSource);

			string strExpected = "Ali Reza Alavi";

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		// **********
		// **********
		// **********

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod07()
		{
			object objSource = null;

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource, nullValueIsNumeric: true);

			bool blnExpected = true;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod08()
		{
			object objSource = null;

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource, nullValueIsNumeric: false);

			bool blnExpected = false;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod09()
		{
			object objSource = "";

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource);

			bool blnExpected = false;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod10()
		{
			object objSource = "     ";

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource);

			bool blnExpected = false;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod11()
		{
			object objSource = "12345";

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource);

			bool blnExpected = true;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod12()
		{
			object objSource = "     12345     ";

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource, spacesInBothSidesIsAllowed: true);

			bool blnExpected = true;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod13()
		{
			object objSource = "     12345     ";

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource, spacesInBothSidesIsAllowed: false);

			bool blnExpected = false;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod14()
		{
			object objSource = "     123     456     ";

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource, spacesInBothSidesIsAllowed: true);

			bool blnExpected = false;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod15()
		{
			object objSource = "     123     456     ";

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource, spacesInBothSidesIsAllowed: false);

			bool blnExpected = false;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod16()
		{
			object objSource = "12345.12345";

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource);

			bool blnExpected = true;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod17()
		{
			object objSource = "12345.";

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource);

			bool blnExpected = true;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod18()
		{
			object objSource = "12345.12345.12345";

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource);

			bool blnExpected = false;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod19()
		{
			object objSource = "12345 12345";

			bool blnActual =
				Dtx.Text.Utility.IsNumeric(value: objSource);

			bool blnExpected = false;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: blnExpected, actual: blnActual);
		}
	}
}
