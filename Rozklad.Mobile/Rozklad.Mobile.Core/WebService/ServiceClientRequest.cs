using System.Collections.Generic;

namespace Rozklad.Mobile.Core.WebService
{
	public class ServiceClientRequest : IServiceClientRequest
	{
		public IDictionary<string, object> Parameters { get; set; }
		public IDictionary<string, string> Headers { get; set; }
		public IDictionary<string, string> Cookie { get; set; }
	}
}
