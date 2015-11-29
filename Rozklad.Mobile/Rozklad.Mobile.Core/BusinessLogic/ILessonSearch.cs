using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public interface ILessonSearch
	{
		Task<Lesson> GetByIdAsync(int id);
		Task<IEnumerable<Lesson>> GetLessonsForGroupAsync(int groupId);
	}
}
