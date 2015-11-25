namespace Rozklad.Mobile.Core.Entities
{
	public class Discipline : EntityBase
	{
		public string Name { get; set; }
		public string FullName { get; set; }

		public static Discipline Convert(Rozklad.Mobile.Core.WebService.DataContracts.Response.Discipline webEntity)
		{
			var entity =
				new Discipline
				{
					Id = webEntity.Id,
					FullName = webEntity.FullName,
					Name = webEntity.Name
				};

			return entity;
		}
	}
}
