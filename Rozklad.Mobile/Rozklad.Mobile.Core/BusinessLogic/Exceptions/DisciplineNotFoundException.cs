using System;

namespace Rozklad.Mobile.Core.BusinessLogic.Exceptions
{
	public class DisciplineNotFoundException : EntityNotFoundException<Entities.Discipline>
	{
		public DisciplineNotFoundException(int disciplineId)
			: base(disciplineId)
		{ }

		public DisciplineNotFoundException(int disciplineId, Exception innerException)
			: base(disciplineId, innerException)
		{ }
	}
}
