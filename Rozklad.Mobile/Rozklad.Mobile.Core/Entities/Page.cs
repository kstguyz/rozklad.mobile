using System.Collections.Generic;

namespace Rozklad.Mobile.Core.Entities
{
	public class Page<TEntity>
		where TEntity : EntityBase
	{
		public int Count { get; set; }
		public int PageNumber { get; set; }
		public int Offset { get; set; }
		public int Limit { get; set; }

		public IEnumerable<TEntity> Results { get; set; } 
	}
}
