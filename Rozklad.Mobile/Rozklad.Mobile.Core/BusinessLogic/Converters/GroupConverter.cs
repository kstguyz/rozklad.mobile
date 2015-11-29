namespace Rozklad.Mobile.Core.BusinessLogic.Converters
{
	public class GroupConverter
		: EntityConverterBase<Entities.Group, WebService.DataContracts.Response.Group>, IGroupConverter
	{
		public override Entities.Group Convert(WebService.DataContracts.Response.Group webEntity)
		{
			var entity = Entities.Group.Convert(webEntity);

			return entity;
		}
	}
}
