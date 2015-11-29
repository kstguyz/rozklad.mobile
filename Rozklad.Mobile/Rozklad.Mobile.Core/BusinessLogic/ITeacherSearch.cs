using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public interface ITeacherSearch
	{
		Task<Teacher> GetByIdAsync(int id);
		Task<IEnumerable<Teacher>> GetByIdsAsync(IEnumerable<int> ids);
	}
}
