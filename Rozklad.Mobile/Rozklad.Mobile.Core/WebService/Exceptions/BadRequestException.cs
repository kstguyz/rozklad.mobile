using System;

namespace Rozklad.Mobile.Core.WebService.Exceptions
{
    public class BadRequestException : WebServiceException
    {
        public BadRequestException()
        { }

        public BadRequestException(string message) 
			: base(message)
        { }

        public BadRequestException(string message, Exception inner) 
			: base (message, inner)
        { }
    }
}
