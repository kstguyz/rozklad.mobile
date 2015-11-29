using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Rozklad.Mobile.Core.Entities
{
	public class Lesson : EntityBase
	{
		public byte Number { get; set; }
		public byte Day { get; set; }
		public byte Week { get; set; }
		public LessonType LessonType { get; set; }
		public byte DisciplineName { get; set; }
		[Ignore]
		public Discipline Discipline { get; set; }
		public int DisciplineId { get; set; }
		public IEnumerable<string> GroupNames { get; set; }
		[Ignore]
		public IEnumerable<Group> Groups { get; set; }
		public IEnumerable<int> GroupIds { get; set; }
		public IEnumerable<string> TeacherShortNames { get; set; }
		[Ignore]
		public IEnumerable<Teacher> Teachers { get; set; }
		public IEnumerable<int> TeacherIds { get; set; }
		public IEnumerable<string> RoomFullNames { get; set; }
		[Ignore]
		public IEnumerable<Room> Rooms { get; set; }
		public IEnumerable<int> RoomIds { get; set; }

		public static Lesson Convert(Rozklad.Mobile.Core.WebService.DataContracts.Response.Lesson webEntity)
		{
			var entity =
				new Lesson
				{
					Id = webEntity.Id,
					Number = webEntity.Number,
					Day = webEntity.Day,
					Week = webEntity.Week,
					LessonType = (LessonType)webEntity.TypeId,
					DisciplineName = webEntity.DisciplineName,
					DisciplineId = webEntity.DisciplineId,
					GroupNames = webEntity.GroupNames,
					GroupIds = webEntity.GroupIds,
					TeacherShortNames = webEntity.TeacherShortNames,
					TeacherIds = webEntity.TeacherIds,
					RoomFullNames = webEntity.RoomFullNames,
					RoomIds = webEntity.RoomIds
				};

			return entity;
		}
	}
}
