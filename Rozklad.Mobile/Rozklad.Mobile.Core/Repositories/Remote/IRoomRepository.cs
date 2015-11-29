using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public interface IRoomRepository : IRemoteRepositoryAsync<Room>
	{
		Task<PageResults<Room>> FilterAsync(string name = "", int? buildingId = null);
		Task<IEnumerable<Room>> FilterAllAsync(string name = "", int? buildingId = null);
	}
}
