using System.Threading.Tasks;

namespace Rozklad.Mobile.Core.WebService.Rest
{
	public interface IRestServiceClient
	{
		Task<TDataTransferObject> GetAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null);

		Task<TDataTransferObject> PostAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null);

		Task<byte[]> PostAsync(string uri, IServiceClientRequest request = null);

		Task<TDataTransferObject> PutAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null);

		Task<TDataTransferObject> DeleteAsync<TDataTransferObject>(string uri, IServiceClientRequest request = null);

		/// <summary>
		/// Adds authenticator into client's collection. Can be applied by calling UseAuthenticator method.
		/// </summary>
		/// <param name="key">Key to be associated with authenticator</param>
		/// <param name="authConfig">Authenticator configuration</param>
		void AddAuthenticator(string key, IRestServiceAuthenticationConfig authConfig);

		/// <summary>
		/// Applies authenticator to be used for all subsequent requests. Authenticator must be added using AddAuthenticator method prior to this method call.
		/// </summary>
		/// <param name="key">Key associated with authenticator</param>
		void UseAuthenticator(string key);

		/// <summary>
		/// Gets or sets a value indicating whether proxy should be used for all requests
		/// </summary>
		/// <value><c>true</c> if use proxy; otherwise, <c>false</c>.</value>
		bool UseProxy { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this
		/// <see cref="IRestServiceClient"/> should use server certificate validation.
		/// </summary>
		/// <value><c>true</c> if enable server certificate validation; otherwise, <c>false</c>.</value>
		bool IgnoreServerCertificateValidation { get; set; }
	}
}
