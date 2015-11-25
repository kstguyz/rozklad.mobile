using Newtonsoft.Json;

namespace Rozklad.Mobile.Core.WebService.DataContracts.Response
{
	public abstract class ResponseEntityBase : ResponseBase
	{
		[JsonProperty("id")]
		public int Id { get; set; }
	}
}
