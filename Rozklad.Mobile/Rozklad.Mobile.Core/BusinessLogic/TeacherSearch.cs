using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public class TeacherSearch : ITeacherSearch
	{
		private readonly Repositories.Remote.ITeacherRepository remoteTeacherRepository;
		private readonly Repositories.Local.ITeacherRepository localTeacherRepository;
		private readonly Converters.ITeacherConverter teacherConverter;
		private readonly IEntityFetcher entityFetcher;

		public TeacherSearch(Repositories.Remote.ITeacherRepository remoteTeacherRepository,
							 Repositories.Local.ITeacherRepository localTeacherRepository,
							 Converters.ITeacherConverter teacherConverter,
							 IEntityFetcher entityFetcher)
		{
			remoteTeacherRepository.ThrowIfNull(nameof(remoteTeacherRepository));
			localTeacherRepository.ThrowIfNull(nameof(localTeacherRepository));
			teacherConverter.ThrowIfNull(nameof(teacherConverter));
			entityFetcher.ThrowIfNull(nameof(entityFetcher));

			this.remoteTeacherRepository = remoteTeacherRepository;
			this.localTeacherRepository = localTeacherRepository;
			this.teacherConverter = teacherConverter;
			this.entityFetcher = entityFetcher;
		}

		public async Task<Entities.Teacher> GetByIdAsync(int id)
		{
			var entity = await entityFetcher.FetchAndCacheAsync(id, remoteTeacherRepository, localTeacherRepository, teacherConverter);

			return entity;
		}

		public async Task<IEnumerable<Entities.Teacher>> GetByIdsAsync(IEnumerable<int> ids)
		{
			var entities = await entityFetcher.FetchAndCacheAsync(ids, remoteTeacherRepository, localTeacherRepository, teacherConverter);

			return entities;
		}
	}
}
