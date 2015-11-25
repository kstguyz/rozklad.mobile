using System;

namespace Rozklad.Mobile.Core.DataBase
{
	public class CannotCreateTableException : Exception
	{
		public CannotCreateTableException(string message)
			: base(message)
		{ }

		public CannotCreateTableException(string message, Exception innerException)
			: base(message, innerException)
		{ }

		public CannotCreateTableException(Type entityType, Exception innerException)
			: base($"Cannot create table for entity {entityType.FullName}", innerException)
		{ }
	}
}
