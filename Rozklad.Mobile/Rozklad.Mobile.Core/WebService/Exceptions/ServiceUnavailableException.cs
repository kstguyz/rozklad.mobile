using System;

namespace Rozklad.Mobile.Core.WebService.Exceptions
{
	public class ServiceUnavailableException : WebServiceException
	{
		public ServiceUnavailableException()
		{ }

		public ServiceUnavailableException(string message) 
			: base(message)
		{ }

		public ServiceUnavailableException(string message, Exception inner)
			: base(message, inner)
		{ }
	}
}

