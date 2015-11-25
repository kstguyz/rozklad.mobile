using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.LocalRepositories
{
	public class TeacherRepository : LocalRepositoryAsyncBase<Teacher>
	{
		public TeacherRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}
