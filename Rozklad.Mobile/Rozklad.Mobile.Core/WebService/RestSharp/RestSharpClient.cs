using System.Threading.Tasks;
using Rozklad.Mobile.Core.WebService.Rest;

namespace Rozklad.Mobile.Core.WebService.RestSharp
{
	public class RestSharpClient : IRestServiceClient
	{
		private readonly IRestServiceEndpointExecutor endPointExecutor;
		private readonly IServerCertificateValidation certificateValidation;

		public RestSharpClient(IServerCertificateValidation certificateValidation = null, IRestSharpProxyFactory proxyFactory = null)
		{
			this.certificateValidation = certificateValidation;
			endPointExecutor = new RestSharpEndpointExecutor(proxyFactory);
		}

		public bool UseProxy
		{
			get { return endPointExecutor.UseProxy; }
			set { endPointExecutor.UseProxy = value; }
		}

		public bool IgnoreServerCertificateValidation
		{
			get { return certificateValidation?.IgnoreCertificateValidation ?? false; }
			set
			{
				if (certificateValidation != null)
				{
					certificateValidation.IgnoreCertificateValidation = value;
				}
			}
		}

		public async Task<TDataTransferObject> GetAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null)
		{
			return await endPointExecutor.ExecuteRequestAsync<TDataTransferObject>(uri, request, RestMethodType.Get);
		}

		public async Task<TDataTransferObject> PostAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null)
		{
			return await endPointExecutor.ExecuteRequestAsync<TDataTransferObject>(uri, request, RestMethodType.Post);
		}

		public async Task<byte[]> PostAsync(string uri, IServiceClientRequest request = null)
		{
			return await endPointExecutor.ExecuteContentAsync(uri, request, RestMethodType.Post);
		}

		public async Task<TDataTransferObject> PutAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null)
		{
			return await endPointExecutor.ExecuteRequestAsync<TDataTransferObject>(uri, request, RestMethodType.Put);
		}

		public async Task<TDataTransferObject> DeleteAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null)
		{
			return await endPointExecutor.ExecuteRequestAsync<TDataTransferObject>(uri, request, RestMethodType.Delete);
		}

		public void AddAuthenticator(string key, IRestServiceAuthenticationConfig authConfig)
		{
			endPointExecutor.AddAuthenticator(key, authConfig);
		}

		public void UseAuthenticator(string key)
		{
			endPointExecutor.UseAuthenticator(key);
		}
	}
}
