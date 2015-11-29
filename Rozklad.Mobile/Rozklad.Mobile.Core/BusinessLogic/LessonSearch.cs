using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public class LessonSearch : ILessonSearch
	{
		private readonly Repositories.Remote.ILessonRepository remoteLessonRepository;
		private readonly Repositories.Local.ILessonRepository localLessonRepository;
		private readonly Converters.ILessonConverter lessonConverter;
		private readonly IEntityFetcher entityFetcher;
		private readonly IDisciplineSearch disciplineSearch;
		private readonly IGroupSearch groupSearch;
		private readonly ITeacherSearch teacherSearch;
		private readonly IRoomSearch roomSearch;

		public LessonSearch(Repositories.Remote.ILessonRepository remoteLessonRepository,
							Repositories.Local.ILessonRepository localLessonRepository,
							Converters.ILessonConverter lessonConverter,
							IEntityFetcher entityFetcher,
                            IDisciplineSearch disciplineSearch,
							IGroupSearch groupSearch,
                            ITeacherSearch teacherSearch,
							IRoomSearch roomSearch)
		{
			remoteLessonRepository.ThrowIfNull(nameof(remoteLessonRepository));
			localLessonRepository.ThrowIfNull(nameof(localLessonRepository));
			lessonConverter.ThrowIfNull(nameof(lessonConverter));
			entityFetcher.ThrowIfNull(nameof(entityFetcher));
			disciplineSearch.ThrowIfNull(nameof(disciplineSearch));
			groupSearch.ThrowIfNull(nameof(groupSearch));
			teacherSearch.ThrowIfNull(nameof(teacherSearch));
			roomSearch.ThrowIfNull(nameof(roomSearch));

			this.remoteLessonRepository = remoteLessonRepository;
			this.localLessonRepository = localLessonRepository;
			this.lessonConverter = lessonConverter;
			this.entityFetcher = entityFetcher;
			this.disciplineSearch = disciplineSearch;
			this.groupSearch = groupSearch;
			this.teacherSearch = teacherSearch;
			this.roomSearch = roomSearch;
		}

		public async Task<IEnumerable<Entities.Lesson>> GetLessonsForGroupAsync(int groupId)
		{
			try
			{
				var lessonsResponses = await remoteLessonRepository.FilterAllAsync(groupId);
				var count = lessonsResponses.Count();
                var lessons = new List<Entities.Lesson>(count);
				foreach (var lesonResponse in lessonsResponses)
				{
					var lesson = await ConvertAsync(lesonResponse);
					lessons.Add(lesson);
                }

				return lessons;
			}
			catch (Exception e)
			{
				e.LogToConsole();

				return new Entities.Lesson[0];
			}
		}

		public async Task<Entities.Lesson> GetByIdAsync(int id)
		{
			var entity = await entityFetcher.FetchAndCacheAsync(id, remoteLessonRepository, localLessonRepository, lessonConverter);

			return entity;
		}

		private async Task<Entities.Lesson> ConvertAsync(WebService.DataContracts.Response.Lesson webEntity)
		{
			var entity = Entities.Lesson.Convert(webEntity);

			entity.Discipline = await disciplineSearch.GetByIdAsync(entity.DisciplineId);
			entity.Groups = await groupSearch.GetByIdsAsync(entity.GroupIds);
			entity.Teachers = await teacherSearch.GetByIdsAsync(entity.TeacherIds);
			entity.Rooms = await roomSearch.GetByIdsAsync(entity.RoomIds);

			return entity;
		}
	}
}
