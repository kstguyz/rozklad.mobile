namespace Rozklad.Mobile.Core.BusinessLogic.Converters
{
	public class BuildingConverter
		: EntityConverterBase<Entities.Building, WebService.DataContracts.Response.Building>, IBuildingConverter
	{
		public override Entities.Building Convert(WebService.DataContracts.Response.Building webEntity)
		{
			var entity = Entities.Building.Convert(webEntity);

			return entity;
		}
	}
}
