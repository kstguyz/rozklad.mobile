using System;

namespace Rozklad.Mobile.Core.WebService.Exceptions
{
	public class WebServiceException : Exception
	{
		public WebServiceException()
		{ }

		public WebServiceException(string message) 
			: base(message)
		{ }

		public WebServiceException(string message, Exception innerException)
			: base(message, innerException)
		{ }
	}
}
