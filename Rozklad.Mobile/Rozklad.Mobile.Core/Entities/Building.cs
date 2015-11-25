namespace Rozklad.Mobile.Core.Entities
{
	public class Building : EntityBase
	{
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public static Building Convert(Rozklad.Mobile.Core.WebService.DataContracts.Response.Building webEntity)
		{
			var entity =
				new Building
				{
					Id = webEntity.Id,
					Latitude = webEntity.Latitude,
					Longitude = webEntity.Longitude,
					Name = webEntity.Name
				};

			return entity;
		}
	}
}
