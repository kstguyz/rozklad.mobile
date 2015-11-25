using Newtonsoft.Json;

namespace Rozklad.Mobile.Core.WebService.DataContracts.Response
{
	public class Room : ResponseEntityBase
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("full_name")]
		public string FullName { get; set; }

		[JsonProperty("kpimaps_id")]
		public int? KpiMapsId { get; set; }

		[JsonProperty("building")]
		public int BuildingId { get; set; }
	}
}
