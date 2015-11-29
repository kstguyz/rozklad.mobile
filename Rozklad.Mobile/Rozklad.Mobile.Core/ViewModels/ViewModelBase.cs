using System;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Rozklad.Mobile.Core.Extensions;
using Rozklad.Mobile.Core.PlatformServices;

namespace Rozklad.Mobile.Core.ViewModels
{
	public class ViewModelBase : MvxViewModel
	{
		protected readonly IDeviceInformation DeviceInformation;
		private readonly ICommand closeCommand;

		public ICommand CloseCommand => closeCommand;

		protected ViewModelBase()
		{
			closeCommand = new MvxCommand(DoCloseCommand);
			DeviceInformation = Mvx.Resolve<IDeviceInformation>();
		}

		protected virtual bool IsInternetConnectionAvailable()
		{
			var task = DeviceInformation.HasInternetConnectionAsync();
			var result = task.Result;

			return result;
		}

		protected virtual void DoCloseCommand()
		{
			try
			{
				Close(this);
			}
			catch (Exception e)
			{
				e.LogToConsole();
			}
		}

		protected virtual void DoShowViewModel<TViewModel>() where TViewModel : IMvxViewModel
		{
			try
			{
				DoShowViewModel<TViewModel>((object)null);
			}
			catch (Exception e)
			{
				e.LogToConsole();
			}
		}

		protected void DoShowViewModel<T>(object parameterValuesObject) where T : IMvxViewModel
		{
			try
			{
				var requestedBy = MvxRequestedBy.UserAction;
				ShowViewModel<T>(parameterValuesObject, null, requestedBy);
			}
			catch (Exception e)
			{
				e.LogToConsole();
			}
		}
	}
}
