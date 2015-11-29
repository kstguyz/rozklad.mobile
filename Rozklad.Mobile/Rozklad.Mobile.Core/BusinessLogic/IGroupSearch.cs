using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public interface IGroupSearch
	{
		Task<Group> GetFirstByNameAsync(string name);
		Task<IEnumerable<Group>> GetByNameAsync(string name);
        Task<Group> GetByIdAsync(int id);
		Task<IEnumerable<Group>> GetByIdsAsync(IEnumerable<int> ids);
	}
}
