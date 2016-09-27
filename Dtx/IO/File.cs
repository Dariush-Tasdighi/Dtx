namespace Dtx.IO
{
	public static class File
	{
		static File()
		{
		}

		public static Generic.Result<string> Read(string pathName)
		{
			Generic.Result<string> oResult = new Generic.Result<string>();

			if (Dtx.String.IsNullOrEmptyOrWhiteSpace(pathName))
			{
				ApplicationException oApplicationException =
					new ApplicationException(message: Resources.Messages.ErrorMessage001, number: 1);

				oResult.Success = false;
				oResult.Exception = oApplicationException;

				return (oResult);
			}

			if (System.IO.File.Exists(pathName) == false)
			{
				ApplicationException oApplicationException =
					new ApplicationException(message: Resources.Messages.ErrorMessage002, number: 2);

				oResult.Success = false;
				oResult.Exception = oApplicationException;

				return (oResult);
			}

			string strResult = string.Empty;

			System.IO.StreamReader oStream = null;

			try
			{
				oStream =
					new System.IO.StreamReader
						(path: pathName, encoding: System.Text.Encoding.UTF8);

				strResult = oStream.ReadToEnd();

				oResult.Success = false;
				oResult.Data = strResult;

				return (oResult);
			}
			catch (System.Exception ex)
			{
				oResult.Success = false;
				oResult.Exception = ex;

				return (oResult);
			}
			finally
			{
				if (oStream != null)
				{
					//oStream.Close();
					oStream.Dispose();
					oStream = null;
				}
			}
		}

		public static Result Write(string pathName, string text, bool append)
		{
			Result oResult = new Result();

			if (Dtx.String.IsNullOrEmptyOrWhiteSpace(pathName))
			{
				ApplicationException oApplicationException =
					new ApplicationException(message: Resources.Messages.ErrorMessage001, number: 1);

				oResult.Success = false;
				oResult.Exception = oApplicationException;

				return (oResult);
			}

			if (text == null)
			{
				text = string.Empty;
			}

			System.IO.StreamWriter oStream = null;

			try
			{
				oStream =
					new System.IO.StreamWriter
						(path: pathName, append: append, encoding: System.Text.Encoding.UTF8);

				oStream.Write(text);

				oResult.Success = true;

				return (oResult);
			}
			catch (System.Exception ex)
			{
				oResult.Success = false;
				oResult.Exception = ex;

				return (oResult);
			}
			finally
			{
				if (oStream != null)
				{
					//oStream.Close();
					oStream.Dispose();
					oStream = null;
				}
			}
		}

		public static Result Append(string pathName, string text)
		{
			return (Write(pathName, text, append: true));
		}

		public static Result Overwrite(string pathName, string text)
		{
			return (Write(pathName, text, append: false));
		}

		public static string GetFileNameByCulture
			(string name, string extension, string cultureName)
		{
			string strFileName = name;

			strFileName =
				string.Format("{0}.{1}.{2}",
				strFileName, cultureName, extension);

			return (strFileName);
		}

		public static string GetFileNameByCurrentCulture(string name, string extension)
		{
			string strFileName =
				GetFileNameByCulture
					(name: name,
					extension: extension,
					cultureName: Dtx.Globalization.CultureInfo.GetCurrentCultureName());

			return (strFileName);
		}

		public static string GetPathNameByCulture
			(string rootRelativePath, string name, string extension, string cultureName)
		{
			string strFileName =
				GetFileNameByCulture
					(name: name,
					extension: extension,
					cultureName: cultureName);

			string strRootRelativePathName =
				string.Format("{0}/{1}", rootRelativePath, strFileName);

			string strPathName =
				System.Web.HttpContext.Current.Server.MapPath(strRootRelativePathName);

			return (strPathName);
		}

		public static string GetPathNameByCurrentCulture
			(string rootRelativePath, string name, string extension)
		{
			string strPathName =
				GetPathNameByCulture
					(rootRelativePath: rootRelativePath,
					name: name,
					extension: extension,
					cultureName: Dtx.Globalization.CultureInfo.GetCurrentCultureName());

			return (strPathName);
		}
	}
}
