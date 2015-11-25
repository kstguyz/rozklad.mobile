using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.Repositories.Local
{
	public class BuildingRepository : LocalRepositoryAsyncBase<Building>, IBuildingRepository
	{
		public BuildingRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}