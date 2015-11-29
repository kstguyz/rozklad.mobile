using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Configuration;
using Rozklad.Mobile.Core.Entities;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;
using Rozklad.Mobile.Core.WebService.Rest;
using Group = Rozklad.Mobile.Core.WebService.DataContracts.Response.Group;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public class GroupRepository : RemoteRepositoryAsyncBase<Group>, IGroupRepository
	{
		public GroupRepository(IRestServiceClient restServiceClient, string url) 
			: base(restServiceClient, url)
		{ }

		public async Task<PageResults<Group>> FilterAsync(string name = "", GroupType? groupType = null, GroupDegree? groupDegree = null)
		{
			var parameters = ProduceParameters(name, groupType, groupDegree);
			var result = await GetFilteredAsync(parameters);

			return result;
		}

		public async Task<IEnumerable<Group>> FilterAllAsync(string name = "", GroupType? groupType = null, GroupDegree? groupDegree = null)
		{
			var parameters = ProduceParameters(name, groupType, groupDegree);
			var result = await GetAllFilteredAsync(parameters);

			return result;
		}

		private static List<KeyValuePair<string, object>> ProduceParameters(string name = "", GroupType? groupType = null, GroupDegree? groupDegree = null)
		{
			var parameters = new List<KeyValuePair<string, object>>();
			if (string.IsNullOrEmpty(name) == false)
			{
				parameters.Add(GetNameParameter(name));
			}
			if (groupType.HasValue == true)
			{
				parameters.Add(GetGroupTypeParameter(groupType.Value));
			}
			if (groupDegree.HasValue == true)
			{
				parameters.Add(GetGroupDegreeParameter(groupDegree.Value));
			}

			return parameters;
		}

		private static KeyValuePair<string, object> GetGroupDegreeParameter(GroupDegree groupDegree)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Group.GroupDegree, (int)groupDegree);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetGroupTypeParameter(GroupType groupType)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Group.GroupType, (int)groupType);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetNameParameter(string name)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Group.Name, name);

			return keyValuePair;
		}
	}
}