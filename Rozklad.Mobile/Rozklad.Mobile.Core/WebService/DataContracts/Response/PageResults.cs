using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rozklad.Mobile.Core.WebService.DataContracts.Response
{
	public class PageResults<TEntity> : ResponseBase
		where TEntity : ResponseEntityBase
	{
		[JsonProperty("count")]
		public int TotalCount { get; set; }

		[JsonProperty("next")]
		public int NextResultsUrl { get; set; }

		[JsonProperty("previous")]
		public int PreviousResultsUrl { get; set; }

		[JsonProperty("results")]
		public IEnumerable<TEntity> Results { get; set; } = new TEntity[0];
	}
}
