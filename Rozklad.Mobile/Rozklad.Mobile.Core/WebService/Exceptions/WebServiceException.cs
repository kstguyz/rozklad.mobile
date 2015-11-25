using System;

namespace Rozklad.Mobile.Core.WebService.Exceptions
{
	public abstract class WebServiceException : Exception
	{
		protected WebServiceException()
		{ }

		protected WebServiceException(string message) 
			: base(message)
		{ }

		protected WebServiceException(string message, Exception innerException)
			: base(message, innerException)
		{ }
	}
}
