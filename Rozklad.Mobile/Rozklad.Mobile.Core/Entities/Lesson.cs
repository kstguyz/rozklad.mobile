using System.Collections.Generic;

namespace Rozklad.Mobile.Core.Entities
{
	public class Lesson : EntityBase
	{
		public byte Number { get; set; }
		public byte Day { get; set; }
		public byte Week { get; set; }
		public LessonType LessonType { get; set; }
		public byte DisciplineName { get; set; }
		public Discipline Discipline { get; set; }
		public IEnumerable<string> GroupsNames { get; set; }
		public IEnumerable<Group> Groups { get; set; }
		public IEnumerable<string> TeachersShortNames { get; set; }
		public IEnumerable<Teacher> Teachers { get; set; }
		public IEnumerable<string> RoomsFullNames { get; set; }
		public IEnumerable<Room> Rooms { get; set; }

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
					//Discipline = webEntity.DisciplineId,
					GroupsNames = webEntity.GroupsNames,
					//Groups = webEntity.GroupsIds,
					TeachersShortNames = webEntity.TeachersShortNames,
					//Teachers = webEntity.TeachersIds,
					RoomsFullNames = webEntity.RoomsFullNames,
					//Rooms = webEntity.RoomsIds
				};

			return entity;
		}
	}
}
