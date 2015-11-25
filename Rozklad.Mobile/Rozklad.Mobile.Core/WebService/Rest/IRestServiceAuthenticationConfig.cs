
namespace Rozklad.Mobile.Core.WebService.Rest
{
	public interface IRestServiceAuthenticationConfig
	{
		RestServiceAuthenticationType AuthType { get; set; }
		string Username { get; set; }
		string Password { get; set; }
		string OAuthTokenEndpointUrl { get; set; }
		string OAuthServiceBody { get; set; }
	}
}
