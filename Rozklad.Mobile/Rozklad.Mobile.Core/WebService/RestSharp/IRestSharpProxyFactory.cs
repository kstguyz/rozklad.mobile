using System.Net;

namespace Rozklad.Mobile.Core.WebService.RestSharp
{
	public interface IRestSharpProxyFactory
	{
		IWebProxy CreateDefaultProxy();
	}
}
