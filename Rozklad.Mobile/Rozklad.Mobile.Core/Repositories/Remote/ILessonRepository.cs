using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Entities;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;
using Lesson = Rozklad.Mobile.Core.WebService.DataContracts.Response.Lesson;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public interface ILessonRepository : IRemoteRepositoryAsync<Lesson>
	{
		Task<PageResults<Lesson>> FilterAsync(int? groupId = null,
		                                      byte? number = null,
		                                      byte? day = null,
		                                      byte? week = null,
		                                      LessonType? lessonType = null,
		                                      int? disciplineId = null,
		                                      int? teacherId = null,
		                                      int? roomId = null);

		Task<IEnumerable<Lesson>> FilterAllAsync(int? groupId = null,
		                                         byte? number = null,
		                                         byte? day = null,
		                                         byte? week = null,
		                                         LessonType? lessonType = null,
		                                         int? disciplineId = null,
		                                         int? teacherId = null,
		                                         int? roomId = null);
	}
}
