using Newtonsoft.Json;

namespace Rozklad.Mobile.Core.WebService.DataContracts.Response
{
	public class Group : ResponseEntityBase
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("okr")]
		public int OkrId { get; set; }

		[JsonProperty("type")]
		public int TypeId { get; set; }
	}
}
