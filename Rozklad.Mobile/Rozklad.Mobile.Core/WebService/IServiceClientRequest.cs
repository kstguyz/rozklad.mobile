using System.Collections.Generic;

namespace Rozklad.Mobile.Core.WebService
{
	public interface IServiceClientRequest
	{
		IDictionary<string, object> Parameters { get; }
		IDictionary<string, string> Headers { get; }
		IDictionary<string, string> Cookie { get; }
	}
}
