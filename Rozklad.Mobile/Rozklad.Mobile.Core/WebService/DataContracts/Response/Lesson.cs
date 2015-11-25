using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rozklad.Mobile.Core.WebService.DataContracts.Response
{
	public class Lesson : ResponseEntityBase
	{
		[JsonProperty("number")]
		public byte Number { get; set; }

		[JsonProperty("day")]
		public byte Day { get; set; }

		[JsonProperty("week")]
		public byte Week { get; set; }

		[JsonProperty("type")]
		public byte TypeId { get; set; }

		[JsonProperty("discipline_name")]
		public byte DisciplineName { get; set; }

		[JsonProperty("discipline")]
		public byte DisciplineId { get; set; }

		[JsonProperty("groups_names")]
		public IEnumerable<string> GroupsNames { get; set; }

		[JsonProperty("groups")]
		public IEnumerable<int> GroupsIds { get; set; }

		[JsonProperty("teachers_short_names")]
		public IEnumerable<string> TeachersShortNames { get; set; }

		[JsonProperty("teachers")]
		public IEnumerable<int> TeachersIds { get; set; }

		[JsonProperty("rooms_full_names")]
		public IEnumerable<string> RoomsFullNames { get; set; }

		[JsonProperty("rooms")]
		public IEnumerable<int> RoomsIds { get; set; }
	}
}
