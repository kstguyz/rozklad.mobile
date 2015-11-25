using System;

namespace Rozklad.Mobile.Core.WebService.Exceptions
{
    public class ServerErrorException : WebServiceException
    {
        public ServerErrorException()
        { }

        public ServerErrorException(string message) 
			: base(message)
        { }

        public ServerErrorException(string message, Exception inner)
			: base(message, inner)
        { }
    }
}
