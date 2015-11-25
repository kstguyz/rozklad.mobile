using System.Collections.Generic;

namespace Rozklad.Mobile.Core.WebService
{
	public interface IServiceClientRequest
	{
		IDictionary<string, object> Parameters { get; set; }
		IDictionary<string, string> Headers { get; set; }
		IDictionary<string, string> Cookie { get; set; }
	}
}
