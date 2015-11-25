using System;

namespace Rozklad.Mobile.Core.WebService.Exceptions
{
	public class ServiceValidationException : WebServiceException
	{
		public ServiceValidationException()
		{ }

		public ServiceValidationException(string message) 
			: base(message)
		{ }

		public ServiceValidationException(string message, Exception inner)
			: base(message, inner)
		{ }
	}
}
