using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.ViewModels
{
	public class LessonViewModel : ViewModelBase
	{
		private Lesson lesson;

		public Lesson Lesson
		{
			get { return lesson; }
			set
			{
				lesson = value;
				RaiseAllPropertiesChanged();
			}
		}

		public byte Number => lesson.Number;
		public byte Day => lesson.Day;
		public byte Week => lesson.Week;
		public byte DisciplineName => lesson.DisciplineName;
	}
}
