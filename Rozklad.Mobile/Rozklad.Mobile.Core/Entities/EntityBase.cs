using Rozklad.Mobile.Core.DataBase;
using SQLite.Net.Attributes;

namespace Rozklad.Mobile.Core.Entities
{
	public abstract class EntityBase : IEntity
	{
		[PrimaryKey]
		public int Id { get; set; }
	}
}
