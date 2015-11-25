using System.Threading.Tasks;

namespace Rozklad.Mobile.Core.WebService.Rest
{
	public interface IRestServiceEndpointExecutor
	{
		Task<TDto> ExecuteRequestAsync<TDto>(string uri, IServiceClientRequest request, RestMethodType methodType);
		Task<byte[]> ExecuteContentAsync(string uri, IServiceClientRequest request, RestMethodType methodType);
		void AddAuthenticator(string key, IRestServiceAuthenticationConfig authConfig);
		void UseAuthenticator(string key);
		bool UseProxy { get; set; }
	}
}
