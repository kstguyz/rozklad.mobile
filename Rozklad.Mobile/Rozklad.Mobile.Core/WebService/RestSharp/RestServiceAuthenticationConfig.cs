using Rozklad.Mobile.Core.WebService.Rest;

namespace Rozklad.Mobile.Core.WebService.RestSharp
{
	public class RestServiceAuthenticationConfig : IRestServiceAuthenticationConfig
	{
		public RestServiceAuthenticationType AuthType { get; set; }

		public string OAuthServiceBody { get; set; }

		public string OAuthTokenEndpointUrl { get; set; }

		public string Password { get; set; }

		public string Username { get; set; }
	}
}
