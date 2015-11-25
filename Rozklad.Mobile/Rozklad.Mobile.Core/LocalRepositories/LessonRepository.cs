using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.LocalRepositories
{
	public class LessonRepository : LocalRepositoryAsyncBase<Lesson>
	{
		public LessonRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}