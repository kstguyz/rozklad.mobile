using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public class RoomSearch : IRoomSearch
	{
		private readonly Repositories.Remote.IRoomRepository remoteRoomRepository;
		private readonly Repositories.Local.IRoomRepository localRoomRepository;
		private readonly Converters.IRoomConverter roomConverter;
		private readonly IEntityFetcher entityFetcher;
		private readonly IBuildingSearch buildingSearch;

		public RoomSearch(Repositories.Remote.IRoomRepository remoteRoomRepository,
						  Repositories.Local.IRoomRepository localRoomRepository,
						  Converters.IRoomConverter roomConverter,
						  IEntityFetcher entityFetcher,
						  IBuildingSearch buildingSearch)
		{
			remoteRoomRepository.ThrowIfNull(nameof(remoteRoomRepository));
			localRoomRepository.ThrowIfNull(nameof(localRoomRepository));
			roomConverter.ThrowIfNull(nameof(roomConverter));
			entityFetcher.ThrowIfNull(nameof(entityFetcher));
			buildingSearch.ThrowIfNull(nameof(buildingSearch));

			this.remoteRoomRepository = remoteRoomRepository;
			this.localRoomRepository = localRoomRepository;
			this.roomConverter = roomConverter;
			this.entityFetcher = entityFetcher;
			this.buildingSearch = buildingSearch;
		}

		public async Task<Entities.Room> GetByIdAsync(int id)
		{
			var entity = await entityFetcher.FetchAndCacheAsync(id, remoteRoomRepository, localRoomRepository, roomConverter);

			entity.Building = await buildingSearch.GetByIdAsync(entity.BuildingId);

            return entity;
		}

		public async Task<IEnumerable<Entities.Room>> GetByIdsAsync(IEnumerable<int> ids)
		{
			var entities = await entityFetcher.FetchAndCacheAsync(ids, remoteRoomRepository, localRoomRepository, roomConverter);

			foreach (var entity in entities)
			{
				entity.Building = await buildingSearch.GetByIdAsync(entity.BuildingId);
			}

			return entities;
		}
	}
}
