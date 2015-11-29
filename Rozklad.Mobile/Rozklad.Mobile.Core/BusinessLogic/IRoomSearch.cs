using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public interface IRoomSearch
	{
		Task<Room> GetByIdAsync(int id);
		Task<IEnumerable<Room>> GetByIdsAsync(IEnumerable<int> ids);
	}
}
