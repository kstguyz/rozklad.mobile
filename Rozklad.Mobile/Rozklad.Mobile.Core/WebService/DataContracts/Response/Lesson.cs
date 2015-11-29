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
		public IEnumerable<string> GroupNames { get; set; }

		[JsonProperty("groups")]
		public IEnumerable<int> GroupIds { get; set; }

		[JsonProperty("teachers_short_names")]
		public IEnumerable<string> TeacherShortNames { get; set; }

		[JsonProperty("teachers")]
		public IEnumerable<int> TeacherIds { get; set; }

		[JsonProperty("rooms_full_names")]
		public IEnumerable<string> RoomFullNames { get; set; }

		[JsonProperty("rooms")]
		public IEnumerable<int> RoomIds { get; set; }
	}
}
