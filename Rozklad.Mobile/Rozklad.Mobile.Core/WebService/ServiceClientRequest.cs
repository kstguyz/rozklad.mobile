using System.Collections.Generic;

namespace Rozklad.Mobile.Core.WebService
{
	public class ServiceClientRequest : IServiceClientRequest
	{
		private readonly Dictionary<string, object> parameters = new Dictionary<string, object>(); 
		private readonly Dictionary<string, string> headers = new Dictionary<string, string>(); 
		private readonly Dictionary<string, string> cookie = new Dictionary<string, string>(); 

		public IDictionary<string, object> Parameters => parameters;
		public IDictionary<string, string> Headers => headers;
		public IDictionary<string, string> Cookie => cookie;
	}
}
