using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.Repositories.Local
{
	public class GroupRepository : LocalRepositoryAsyncBase<Group>, IGroupRepository
	{
		public GroupRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}