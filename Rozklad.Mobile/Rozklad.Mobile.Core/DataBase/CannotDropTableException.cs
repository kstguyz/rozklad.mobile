using System;

namespace Rozklad.Mobile.Core.DataBase
{
	public class CannotDropTableException : Exception
	{
		public CannotDropTableException(string message)
			: base(message)
		{ }

		public CannotDropTableException(string message, Exception innerException)
			: base(message, innerException)
		{ }

		public CannotDropTableException(Type entityType, Exception innerException)
			: base($"Cannot drop table for entity {entityType.FullName}", innerException)
		{ }
	}
}
