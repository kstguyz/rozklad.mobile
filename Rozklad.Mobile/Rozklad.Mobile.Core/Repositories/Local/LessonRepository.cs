using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.Repositories.Local
{
	public class LessonRepository : LocalRepositoryAsyncBase<Lesson>, ILessonRepository
	{
		public LessonRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}