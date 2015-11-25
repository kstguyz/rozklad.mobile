using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.LocalRepositories
{
	public class DisciplineRepository : LocalRepositoryAsyncBase<Discipline>
	{
		public DisciplineRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}