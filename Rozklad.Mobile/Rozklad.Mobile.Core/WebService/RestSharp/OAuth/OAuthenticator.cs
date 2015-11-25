using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;

namespace Rozklad.Mobile.Core.WebService.RestSharp.OAuth
{
	internal class OAuthenticator : AsyncAuthenticator
	{
		private readonly string oAuthTokenEndpointUrl;
		private readonly string oAuthServiceBody;

		private string token;
		private DateTime expirationDate;

		public OAuthenticator(string oAuthServiceBody, string oAuthTokenEndpointUrl)
		{
			this.oAuthServiceBody = oAuthServiceBody;
			this.oAuthTokenEndpointUrl = oAuthTokenEndpointUrl;
			token = null;
			expirationDate = DateTime.MinValue;
		}

		public override async Task Authenticate(IRestClient client, IRestRequest request)
		{
			if (token == null || expirationDate <= DateTime.UtcNow)
			{
				var restRequest = new RestRequest(oAuthTokenEndpointUrl, HttpMethod.Post);

				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");

				var parameters = ParseQueryString(oAuthServiceBody);
				foreach (var paramerer in parameters)
				{
					restRequest.AddParameter(paramerer.Key, paramerer.Value, ParameterType.GetOrPost);
				}

				// Use separate client to get token in order to prevent infinite loop
				using (IRestClient authClient = new RestClient(oAuthTokenEndpointUrl))
				{
					authClient.Proxy = client.Proxy;

					var response = await authClient.Execute(restRequest);

					if (!response.IsSuccess)
					{
						Utility.ThrowRequestFailed(oAuthTokenEndpointUrl, response);
					}

					var deserializer = authClient.GetHandler(response.ContentType);
					var tokenResponse = deserializer.Deserialize<OAuthClientTokenResponse>(response);
					expirationDate = DateTime.UtcNow.AddSeconds(tokenResponse.expires_in);
					token = $"{tokenResponse.token_type} {tokenResponse.access_token}";
				}
			}

			request.AddHeader(HttpRequestHeader.Authorization.ToString(), token);
		}

		private static Dictionary<string, string> ParseQueryString(string parameterString)
		{
			return (from part in parameterString.Split('&')
					let equalSignPos = part.IndexOf('=')
					let partKey = part.Substring(0, equalSignPos)
					let partValue = part.Substring(equalSignPos + 1)
					select new
					{
						partKey,
						partValue
					}).ToDictionary(x => x.partKey, x => x.partValue);
		}
	}
}
