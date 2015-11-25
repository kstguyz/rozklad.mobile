using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.Repositories.Local
{
	public class TeacherRepository : LocalRepositoryAsyncBase<Teacher>, ITeacherRepository
	{
		public TeacherRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}
