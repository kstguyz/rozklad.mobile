using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.LocalRepositories
{
	public class BuildingRepository : LocalRepositoryAsyncBase<Building>
	{
		public BuildingRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}