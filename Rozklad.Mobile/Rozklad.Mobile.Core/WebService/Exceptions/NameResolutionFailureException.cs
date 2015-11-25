using System;

namespace Rozklad.Mobile.Core.WebService.Exceptions
{	
	public class NameResolutionFailureException : WebServiceException
	{
		public NameResolutionFailureException()
		{ }

		public NameResolutionFailureException(string message) 
			: base(message)
		{ }

		public NameResolutionFailureException(string message, Exception inner) 
			: base(message, inner)
		{ }
	}
}
