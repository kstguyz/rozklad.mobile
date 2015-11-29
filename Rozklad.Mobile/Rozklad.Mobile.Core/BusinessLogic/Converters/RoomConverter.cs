namespace Rozklad.Mobile.Core.BusinessLogic.Converters
{
	public class RoomConverter
		: EntityConverterBase<Entities.Room, WebService.DataContracts.Response.Room>, IRoomConverter
	{
		public override Entities.Room Convert(WebService.DataContracts.Response.Room webEntity)
		{
			var entity = Entities.Room.Convert(webEntity);

			return entity;
		}
	}
}
