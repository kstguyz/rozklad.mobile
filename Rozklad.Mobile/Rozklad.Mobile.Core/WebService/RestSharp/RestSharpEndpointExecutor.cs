using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;
using Rozklad.Mobile.Core.WebService.Rest;
using Rozklad.Mobile.Core.WebService.RestSharp.OAuth;

namespace Rozklad.Mobile.Core.WebService.RestSharp
{
	internal class RestSharpEndpointExecutor : IRestServiceEndpointExecutor
	{
		private readonly Dictionary<string, IAuthenticator> authenticators;
		private readonly IRestSharpProxyFactory proxyFactory;

		private RestClient client;
		private bool useProxy;

		public RestSharpEndpointExecutor(IRestSharpProxyFactory proxyFactory)
		{
			this.proxyFactory = proxyFactory;

			ResetClient();
			authenticators = new Dictionary<string, IAuthenticator>();
		}

		public async Task<byte[]> ExecuteContentAsync(string uri, IServiceClientRequest request, RestMethodType methodType)
		{
			var response = await ExecuteRequestAsync(uri, request, methodType);

			return response.RawBytes;
		}

		public async Task<TDto> ExecuteRequestAsync<TDto>(string uri, IServiceClientRequest request, RestMethodType methodType)
		{
			var response = await ExecuteRequestAsync(uri, request, methodType);
			var deserializer = client.GetHandler(response.ContentType);

			return deserializer.Deserialize<TDto>(response);
		}

		public void AddAuthenticator(string key, IRestServiceAuthenticationConfig authConfig)
		{
			if (authConfig == null)
				throw new ArgumentNullException(nameof(authConfig));

			switch (authConfig.AuthType)
			{
				case RestServiceAuthenticationType.Anonimous:
					authenticators.Add(key, null);
					break;
				case RestServiceAuthenticationType.Basic:
					authenticators.Add(key, new HttpBasicAuthenticator(authConfig.Username, authConfig.Password));
					break;
				case RestServiceAuthenticationType.Digest:
					authenticators.Add(key, new HttpDigestAuthenticator(new NetworkCredential(authConfig.Username, authConfig.Password)));
					break;
				case RestServiceAuthenticationType.NTLM:
					authenticators.Add(key, new NtlmAuthenticator(authConfig.Username, authConfig.Password));
					break;
				case RestServiceAuthenticationType.OAuth:
					authenticators.Add(key, new OAuthenticator(authConfig.OAuthServiceBody, authConfig.OAuthTokenEndpointUrl));
					break;
				default:
					throw new NotSupportedException($"Authentication type '{authConfig.AuthType}' is not supported");
			}
		}

		public void UseAuthenticator(string key)
		{
			if (authenticators.ContainsKey(key))
			{
				ResetClient();
				client.Authenticator = authenticators[key];
			}
			else
			{
				throw new KeyNotFoundException($"There is no authenticator for key '{key}' exist");
			}
		}

		public bool UseProxy
		{
			get
			{
				return useProxy;
			}
			set
			{
				if (useProxy != value)
				{
					client.Proxy = proxyFactory?.CreateDefaultProxy();
					useProxy = value;
				}
			}
		}

		private async Task<IRestResponse> ExecuteRequestAsync(string uri, IServiceClientRequest request, RestMethodType methodType)
		{
			if (string.IsNullOrEmpty(uri))
				throw new ArgumentException("Uri string is null or empty");

			var restRequest = SetupRequest(uri, request, methodType);

			var response = await client.Execute(restRequest);

			if (response.IsSuccess)
				return response;

			Utility.ThrowRequestFailed(uri, response);

			return null;
		}

		private static RestRequest SetupRequest(string uri, IServiceClientRequest request, RestMethodType methodType)
		{
			var mt = new HttpMethod(methodType.ToString().ToUpperInvariant());

			return Utility.CreateRestSharpRequest(uri, request, mt);
		}

		private void ResetClient()
		{
			client?.Dispose();

			// Need to set some base url for RestSharp, otherwise exception is rised on any request
			client =
				new RestClient("http://localhost")
				{
					CookieContainer = new CookieContainer(),
					IgnoreResponseStatusCode = true
				};

			if (useProxy)
			{
				client.Proxy = proxyFactory?.CreateDefaultProxy();
			}
		}
	}
}
