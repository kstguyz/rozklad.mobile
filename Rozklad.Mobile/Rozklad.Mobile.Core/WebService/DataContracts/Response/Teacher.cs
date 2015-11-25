using Newtonsoft.Json;

namespace Rozklad.Mobile.Core.WebService.DataContracts.Response
{
	public class Teacher : ResponseEntityBase
	{
		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("middle_name")]
		public string MiddleName { get; set; }

		[JsonProperty("name")]
		public string FullName { get; set; }

		[JsonProperty("full_name")]
		public string FullNameWithDegree { get; set; }

		[JsonProperty("short_name")]
		public string ShortName { get; set; }

		[JsonProperty("short_name_with_degree")]
		public string ShortNameWithDegree { get; set; }

		[JsonProperty("degree")]
		public string Degree { get; set; }
	}
}
