using System;

namespace Rozklad.Mobile.Core.BusinessLogic.Exceptions
{
	public class EntityNotFoundException<TEntity> : BusinessLogicException
		where TEntity : Entities.EntityBase
	{
		private const string MessageTemplate = "{0} with id {1} not found";

		public EntityNotFoundException(int entityId)
			: base(string.Format(MessageTemplate, GetEntityName(), entityId))
		{ }

		public EntityNotFoundException(int entityId, Exception innerException)
			: base(string.Format(MessageTemplate, GetEntityName(), entityId), innerException)
		{ }

		private static string GetEntityName()
		{
			var type = typeof (TEntity);
			var name = type.Name;

			return name;
		}
	}
}
