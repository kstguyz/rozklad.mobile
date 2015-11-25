using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.LocalRepositories
{
	public class GroupRepository : LocalRepositoryAsyncBase<Group>
	{
		public GroupRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}