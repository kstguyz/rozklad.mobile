namespace Rozklad.Mobile.Core.Entities
{
	public class Group : EntityBase
	{
		public string Name { get; set; }
		public GroupDegree GroupDegree { get; set; }
		public GroupType GroupType { get; set; }

		public static Group Convert(Rozklad.Mobile.Core.WebService.DataContracts.Response.Group webEntity)
		{
			var entity =
				new Group
				{
					Id = webEntity.Id,
					GroupDegree = (GroupDegree)webEntity.OkrId,
					GroupType = (GroupType)webEntity.TypeId,
					Name = webEntity.Name
				};

			return entity;
		}
	}
}
