namespace Rozklad.Mobile.Core.BusinessLogic.Converters
{
	public abstract class EntityConverterBase<TEntity, TWebEntity> : IEntityConverter<TEntity, TWebEntity>
		where TEntity : Entities.EntityBase, new()
		where TWebEntity : WebService.DataContracts.Response.ResponseEntityBase
	{
		public virtual TEntity Convert(TWebEntity webEntity)
		{
			var entity = new TEntity();

			FillEntity(entity, webEntity);

            return entity;
		}

		protected virtual void FillEntity(TEntity entity, TWebEntity webEntity)
		{ }
	}
}
