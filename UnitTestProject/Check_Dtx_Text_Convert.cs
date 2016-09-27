namespace UnitTestProject
{
	[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
	public class Check_Dtx_Text_Convert : object
	{
		public Check_Dtx_Text_Convert()
			: base()
		{
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod01()
		{
			string strSource = null;

			string strActual =
				Dtx.Text.Convert.ToNumberByCulture(value: strSource, numberIsNullCaption: null);

			string strExpected =
				Dtx.Resources.Captions.NumberIsNull;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod02()
		{
			string strSource = null;

			string strActual =
				Dtx.Text.Convert.ToNumberByCulture(value: strSource, numberIsNullCaption: "");

			string strExpected = "";

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod03()
		{
			string strSource = null;

			string strActual =
				Dtx.Text.Convert.ToNumberByCulture(value: strSource, numberIsNullCaption: "Something");

			string strExpected = "Something";

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod04()
		{
			string strSource = "";

			string strActual =
				Dtx.Text.Convert.ToNumberByCulture(value: strSource, numberIsNotValidCaption: null);

			string strExpected =
				Dtx.Resources.Captions.NumberIsNotValid;

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod05()
		{
			string strSource = "";

			string strActual =
				Dtx.Text.Convert.ToNumberByCulture(value: strSource, numberIsNotValidCaption: "");

			string strExpected = "";

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void TestMethod06()
		{
			string strSource = "";

			string strActual =
				Dtx.Text.Convert.ToNumberByCulture(value: strSource, numberIsNotValidCaption: "Something");

			string strExpected = "Something";

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}

		// **********
		// **********
		// **********

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
		public void Test_ToFormattedNumberByCulture_01()
		{
			string strSource = "1234567.123";

			string strActual =
				Dtx.Text.Convert.ToFormattedNumberByCulture(value: strSource);

			string strExpected = "۱,۲۳۴,۵۶۷";

			Microsoft.VisualStudio.TestTools.UnitTesting.Assert
				.AreEqual(expected: strExpected, actual: strActual);
		}
	}
}
