using System;

namespace Rozklad.Mobile.Core.WebService.Exceptions
{
	public class ForbiddenRequestException : WebServiceException
	{
		public ForbiddenRequestException()
		{ }

		public ForbiddenRequestException(string message) 
			: base(message)
		{ }

		public ForbiddenRequestException(string message, Exception inner) 
			: base (message, inner)
		{ }
	}
}
