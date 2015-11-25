using System.Threading.Tasks;
using Rozklad.Mobile.Core.Extensions;
using Rozklad.Mobile.Core.WebService.Rest;

namespace Rozklad.Mobile.Core.WebService
{
	public abstract class WebServiceConnectionAsync
	{
		private readonly IRestServiceClient _restServiceClient;

		protected WebServiceConnectionAsync(IRestServiceClient restServiceClient)
		{
			restServiceClient.ThrowIfNull(nameof(restServiceClient));

			_restServiceClient = restServiceClient;
		}

		protected async Task<TDataTransferObject> GetAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null)
		{
			var result = await _restServiceClient.GetAsync<TDataTransferObject>(uri, request);

			return result;
		}

		protected async Task<TDataTransferObject> PostAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null)
		{
			var result = await _restServiceClient.PostAsync<TDataTransferObject>(uri, request);

			return result;
		}

		protected async Task<byte[]> PostAsync(string uri, IServiceClientRequest request = null)
		{
			var result = await _restServiceClient.PostAsync<byte[]>(uri, request);

			return result;
		}

		protected async Task<TDataTransferObject> PutAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null)
		{
			var result = await _restServiceClient.PostAsync<TDataTransferObject>(uri, request);

			return result;
		}

		protected async Task<TDataTransferObject> DeleteAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null)
		{
			var result = await _restServiceClient.DeleteAsync<TDataTransferObject>(uri, request);

			return result;
		}
	}
}
