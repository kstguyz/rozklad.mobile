namespace Rozklad.Mobile.Core.BusinessLogic.Converters
{
	public class LessonConverter
		: EntityConverterBase<Entities.Lesson, WebService.DataContracts.Response.Lesson>, ILessonConverter
	{
		public override Entities.Lesson Convert(WebService.DataContracts.Response.Lesson webEntity)
		{
			var entity = Entities.Lesson.Convert(webEntity);

			return entity;
		}
	}
}
