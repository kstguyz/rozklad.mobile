using System;

namespace Rozklad.Mobile.Core.WebService.Exceptions
{
    public class UnauthorizedException : WebServiceException
    {
        public UnauthorizedException()
        { }

        public UnauthorizedException(string message) 
			: base(message)
        { }

        public UnauthorizedException(string message, Exception inner) 
			: base (message, inner)
        { }
    }
}
