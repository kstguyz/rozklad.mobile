namespace Rozklad.Mobile.Core.WebService.RestSharp.OAuth
{
	public class OAuthClientTokenResponse
	{
		public string access_token { get; set; }

		public string token_type { get; set; }

		public int expires_in { get; set; }

		public string refresh_token { get; set; }
	}
}
