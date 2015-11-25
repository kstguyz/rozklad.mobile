namespace Rozklad.Mobile.Core.WebService.RestSharp
{
	public interface IServerCertificateValidation
	{
		bool IgnoreCertificateValidation { get; set; }
	}
}
