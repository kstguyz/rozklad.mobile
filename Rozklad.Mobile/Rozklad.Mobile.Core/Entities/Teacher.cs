namespace Rozklad.Mobile.Core.Entities
{
	public class Teacher : EntityBase
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string FullName { get; set; }
		public string FullNameWithDegree { get; set; }
		public string ShortName { get; set; }
		public string ShortNameWithDegree { get; set; }
		public string Degree { get; set; }

		public static Teacher Convert(Rozklad.Mobile.Core.WebService.DataContracts.Response.Teacher webEntity)
		{
			var entity =
				new Teacher
				{
					Id = webEntity.Id,
					LastName = webEntity.LastName,
					FirstName = webEntity.FirstName,
					MiddleName = webEntity.MiddleName,
					FullName = webEntity.FullName,
					FullNameWithDegree = webEntity.FullNameWithDegree,
					ShortName = webEntity.ShortName,
					ShortNameWithDegree = webEntity.ShortNameWithDegree,
					Degree = webEntity.Degree
				};

			return entity;
		}
	}
}
