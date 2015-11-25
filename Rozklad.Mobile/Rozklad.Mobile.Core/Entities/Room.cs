namespace Rozklad.Mobile.Core.Entities
{
	public class Room : EntityBase
	{
		public string Name { get; set; }
		public string FullName { get; set; }
		public int? KpiMapsId { get; set; }
		public Building Building { get; set; }

		public static Room Convert(Rozklad.Mobile.Core.WebService.DataContracts.Response.Room webEntity)
		{
			var entity =
				new Room
				{
					Id = webEntity.Id,
					Name = webEntity.Name,
					KpiMapsId = webEntity.KpiMapsId,
					//Building = webEntity.BuildingId
				};

			return entity;
		}
	}
}
