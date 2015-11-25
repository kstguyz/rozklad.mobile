using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Configuration;
using Rozklad.Mobile.Core.Entities;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;
using Rozklad.Mobile.Core.WebService.Rest;
using Lesson = Rozklad.Mobile.Core.WebService.DataContracts.Response.Lesson;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public class LessonRepository : RemoteRepositoryAsyncBase<Lesson>, ILessonRepository
	{
		public LessonRepository(IRestServiceClient restServiceClient, string url)
			: base(restServiceClient, url)
		{ }

		public async Task<PageResults<Lesson>> FilterAsync(byte? number = null,
		                                                   byte? day = null,
		                                                   byte? week = null,
		                                                   LessonType? lessonType = null,
		                                                   int? disciplineId = null,
		                                                   int? groupId = null,
		                                                   int? teacherId = null,
		                                                   int? roomId = null)
		{
			var parameters = new List<KeyValuePair<string, object>>();
			if (number.HasValue == true)
			{
				parameters.Add(GetNumberParameter(number.Value));
			}
			if (day.HasValue == true)
			{
				parameters.Add(GetDayParameter(day.Value));
			}
			if (week.HasValue == true)
			{
				parameters.Add(GetWeekParameter(week.Value));
			}
			if (lessonType.HasValue == true)
			{
				parameters.Add(GetLessonTypeParameter(lessonType.Value));
			}
			if (disciplineId.HasValue == true)
			{
				parameters.Add(GetDisciplineParameter(disciplineId.Value));
			}
			if (groupId.HasValue == true)
			{
				parameters.Add(GetGroupParameter(groupId.Value));
			}
			if (teacherId.HasValue == true)
			{
				parameters.Add(GetTeacherParameter(teacherId.Value));
			}
			if (roomId.HasValue == true)
			{
				parameters.Add(GetRoomParameter(roomId.Value));
			}

			var result = await GetFilteredAsync(parameters);

			return result;
		}

		private static KeyValuePair<string, object> GetNumberParameter(byte number)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Lesson.Number, number);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetDayParameter(byte day)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Lesson.Day, day);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetWeekParameter(byte week)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Lesson.Week, week);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetLessonTypeParameter(LessonType lessonType)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Lesson.Type, (int)lessonType);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetDisciplineParameter(int disciplineId)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Lesson.Discipline, disciplineId);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetGroupParameter(int groupId)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Lesson.Groups, groupId);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetTeacherParameter(int teacherId)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Lesson.Teachers, teacherId);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetRoomParameter(int roomId)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Lesson.Rooms, roomId);

			return keyValuePair;
		}
	}
}