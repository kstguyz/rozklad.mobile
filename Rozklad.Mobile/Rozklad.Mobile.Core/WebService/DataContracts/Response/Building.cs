using Newtonsoft.Json;

namespace Rozklad.Mobile.Core.WebService.DataContracts.Response
{
	public class Building : ResponseEntityBase
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("latitude")]
		public double Latitude { get; set; } 

		[JsonProperty("longitude")]
		public double Longitude { get; set; } 
	}
}
