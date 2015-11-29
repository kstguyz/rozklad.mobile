using System;

namespace Rozklad.Mobile.Core.BusinessLogic.Exceptions
{
	public class GroupNotFoundException : EntityNotFoundException<Entities.Group>
	{
		public GroupNotFoundException(int disciplineId)
			: base(disciplineId)
		{ }

		public GroupNotFoundException(int disciplineId, Exception innerException)
			: base(disciplineId, innerException)
		{ }
	}
}
