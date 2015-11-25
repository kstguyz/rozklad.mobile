using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.Repositories.Local
{
	public class DisciplineRepository : LocalRepositoryAsyncBase<Discipline>, IDisciplineRepository
	{
		public DisciplineRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}