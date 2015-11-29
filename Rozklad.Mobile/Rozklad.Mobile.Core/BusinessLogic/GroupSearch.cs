using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public class GroupSearch : IGroupSearch
	{
		private readonly Repositories.Remote.IGroupRepository remoteGroupRepository;
		private readonly Repositories.Local.IGroupRepository localGroupRepository;
		private readonly Converters.IGroupConverter groupConverter;
		private readonly IEntityFetcher entityFetcher;

		public GroupSearch(Repositories.Remote.IGroupRepository remoteGroupRepository,
						   Repositories.Local.IGroupRepository localGroupRepository,
						   Converters.IGroupConverter groupConverter,
						   IEntityFetcher entityFetcher)
		{
			remoteGroupRepository.ThrowIfNull(nameof(remoteGroupRepository));
			localGroupRepository.ThrowIfNull(nameof(localGroupRepository));
			groupConverter.ThrowIfNull(nameof(groupConverter));
			entityFetcher.ThrowIfNull(nameof(entityFetcher));

			this.remoteGroupRepository = remoteGroupRepository;
			this.localGroupRepository = localGroupRepository;
			this.groupConverter = groupConverter;
			this.entityFetcher = entityFetcher;
		}

		public async Task<Entities.Group> GetFirstByNameAsync(string name)
		{
			var groups = await GetByNameAsync(name);
			var group = groups.FirstOrDefault();

			return group;
		}

        public async Task<IEnumerable<Entities.Group>> GetByNameAsync(string name)
		{
			var webEntities = await remoteGroupRepository.FilterAllAsync(name);
			var entities = webEntities.Select(webEntity => groupConverter.Convert(webEntity))
			                          .ToArray();

			return entities;
		}

        public async Task<Entities.Group> GetByIdAsync(int id)
		{
			var entity = await entityFetcher.FetchAndCacheAsync(id, remoteGroupRepository, localGroupRepository, groupConverter);

			return entity;
		}

		public async Task<IEnumerable<Entities.Group>> GetByIdsAsync(IEnumerable<int> ids)
		{
			var entities = await entityFetcher.FetchAndCacheAsync(ids, remoteGroupRepository, localGroupRepository, groupConverter);

			return entities;
		}
	}
}
