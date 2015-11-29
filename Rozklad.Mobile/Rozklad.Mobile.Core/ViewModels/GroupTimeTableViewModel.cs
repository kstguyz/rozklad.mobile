using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Rozklad.Mobile.Core.BusinessLogic;
using Rozklad.Mobile.Core.Extensions;
using Rozklad.Mobile.Core.PlatformServices;

namespace Rozklad.Mobile.Core.ViewModels
{
	public class GroupTimeTableViewModel : ViewModelBase
	{
		private readonly ICommand getGroupScheduleCommand;
		private readonly ISpinner spinner;
		private readonly ILessonSearch lessonSearch;
		private readonly IViewModelFactory viewModelFactory;

		// 4 is for test
		private int groupId = 4;
		//private int groupId = -1
		private IEnumerable<LessonViewModel> lessonViewModels = new LessonViewModel[0];

		public GroupTimeTableViewModel(ISpinner spinner,
									   ILessonSearch lessonSearch,
									   IViewModelFactory viewModelFactory)
		{
			spinner.ThrowIfNull(nameof(spinner));
			lessonSearch.ThrowIfNull(nameof(lessonSearch));
			viewModelFactory.ThrowIfNull(nameof(viewModelFactory));

			this.spinner = spinner;
			this.lessonSearch = lessonSearch;
			this.viewModelFactory = viewModelFactory;

			getGroupScheduleCommand = new MvxCommand(DoGetGroupSchedule);
        }

		public ICommand GetGroupScheduleCommand => getGroupScheduleCommand;

		public int GroupId
		{
			get { return groupId; }
			set
			{
				groupId = value;
				RaisePropertyChanged();
			}
		}

		public IEnumerable<LessonViewModel> LessonViewModels
		{
			get { return lessonViewModels; }
			set
			{
				if (value == null)
				{
					value = new LessonViewModel[0];
				}
				lessonViewModels = value;
				RaisePropertyChanged();
			}
		}

		public async void DoGetGroupSchedule()
		{
			try
			{
				spinner.Start();
				var lessons = await lessonSearch.GetLessonsForGroupAsync(groupId);
				var viewModels =
					lessons.Select(lesson =>
					               {
						               var viewModel = viewModelFactory.Produce<LessonViewModel>();
						               viewModel.Lesson = lesson;

						               return viewModel;
					               })
					       .ToList();

				LessonViewModels = viewModels;
			}
			catch (Exception e)
			{
				e.LogToConsole();
			}
			finally
			{
				spinner.Stop();
			}
		}
	}
}
