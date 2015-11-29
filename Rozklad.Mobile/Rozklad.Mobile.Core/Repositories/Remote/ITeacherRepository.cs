using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public interface ITeacherRepository : IRemoteRepositoryAsync<Teacher>
	{
		Task<PageResults<Teacher>> FilterAsync(string lastName = "", string firstName = "", string middleName = "", string degree = "");
		Task<IEnumerable<Teacher>> FilterAllAsync(string lastName = "", string firstName = "", string middleName = "", string degree = "");
	}
}
