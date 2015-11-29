namespace Rozklad.Mobile.Core.BusinessLogic.Converters
{
	public interface IEntityConverter<out TEntity, in TResponse>
		where TEntity : Entities.EntityBase
		where TResponse : WebService.DataContracts.Response.ResponseEntityBase
	{
		TEntity Convert(TResponse webEntity);
	}
}
