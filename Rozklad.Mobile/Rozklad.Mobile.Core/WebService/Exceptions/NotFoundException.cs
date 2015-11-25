using System;

namespace Rozklad.Mobile.Core.WebService.Exceptions
{
    public class NotFoundException : WebServiceException
	{
        public NotFoundException()
		{ }

        public NotFoundException(string message) 
			: base(message)
        { }

        public NotFoundException(string message, Exception inner) 
			: base(message, inner)
        { }
	}
}
