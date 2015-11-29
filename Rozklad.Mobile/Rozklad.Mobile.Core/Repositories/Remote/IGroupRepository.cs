using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Entities;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;
using Group = Rozklad.Mobile.Core.WebService.DataContracts.Response.Group;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public interface IGroupRepository : IRemoteRepositoryAsync<Group>
	{
		Task<PageResults<Group>> FilterAsync(string name = "", GroupType? groupType = null, GroupDegree? groupDegree = null);
		Task<IEnumerable<Group>> FilterAllAsync(string name = "", GroupType? groupType = null, GroupDegree? groupDegree = null);
	}
}