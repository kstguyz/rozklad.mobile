using System.Threading.Tasks;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public class BuildingSearch : IBuildingSearch
	{
		private readonly Repositories.Remote.IBuildingRepository remoteBuildingRepository;
		private readonly Repositories.Local.IBuildingRepository localBuildingRepository;
		private readonly Converters.IBuildingConverter buildingConverter;
		private readonly IEntityFetcher entityFetcher;

		public BuildingSearch(Repositories.Remote.IBuildingRepository remoteBuildingRepository,
							  Repositories.Local.IBuildingRepository localBuildingRepository,
							  Converters.IBuildingConverter buildingConverter,
							  IEntityFetcher entityFetcher)
		{
			remoteBuildingRepository.ThrowIfNull(nameof(remoteBuildingRepository));
			localBuildingRepository.ThrowIfNull(nameof(localBuildingRepository));
			buildingConverter.ThrowIfNull(nameof(buildingConverter));
			entityFetcher.ThrowIfNull(nameof(entityFetcher));

			this.remoteBuildingRepository = remoteBuildingRepository;
			this.localBuildingRepository = localBuildingRepository;
			this.buildingConverter = buildingConverter;
			this.entityFetcher = entityFetcher;
		}

		public async Task<Entities.Building> GetByIdAsync(int id)
		{
			var entity = await entityFetcher.FetchAndCacheAsync(id, remoteBuildingRepository, localBuildingRepository, buildingConverter);

			return entity;
		}
	}
}
