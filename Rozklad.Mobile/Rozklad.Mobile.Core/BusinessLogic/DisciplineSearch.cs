using System.Threading.Tasks;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public class DisciplineSearch : IDisciplineSearch
	{
		private readonly Repositories.Remote.IDisciplineRepository remoteDisciplineRepository;
		private readonly Repositories.Local.IDisciplineRepository localDisciplineRepository;
		private readonly Converters.IDisciplineConverter disciplineConverter;
		private readonly IEntityFetcher entityFetcher;

		public DisciplineSearch(Repositories.Remote.IDisciplineRepository remoteDisciplineRepository,
								Repositories.Local.IDisciplineRepository localDisciplineRepository,
								Converters.IDisciplineConverter disciplineConverter,
                                IEntityFetcher entityFetcher)
		{
			remoteDisciplineRepository.ThrowIfNull(nameof(remoteDisciplineRepository));
			localDisciplineRepository.ThrowIfNull(nameof(localDisciplineRepository));
			disciplineConverter.ThrowIfNull(nameof(disciplineConverter));
			entityFetcher.ThrowIfNull(nameof(entityFetcher));

			this.remoteDisciplineRepository = remoteDisciplineRepository;
			this.localDisciplineRepository = localDisciplineRepository;
			this.disciplineConverter = disciplineConverter;
			this.entityFetcher = entityFetcher;
		}

		public async Task<Entities.Discipline> GetByIdAsync(int id)
		{
			var entity = await entityFetcher.FetchAndCacheAsync(id, remoteDisciplineRepository, localDisciplineRepository, disciplineConverter);

			return entity;
		}
	}
}
