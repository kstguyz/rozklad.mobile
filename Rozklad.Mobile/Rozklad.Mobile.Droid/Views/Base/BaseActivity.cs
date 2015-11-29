using System;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Rozklad.Mobile.Core.Extensions;
using Rozklad.Mobile.Core.ViewModels;
using Rozklad.Mobile.Droid.Extensions;

namespace Rozklad.Mobile.Droid.Views.Base
{
	public abstract class BaseActivity<TViewModel> : MvxActivity<TViewModel> 
		where TViewModel : ViewModelBase
	{
		public const int DefaultResourceId = -1;

		private readonly int contentResourceId = DefaultResourceId;

		protected BaseActivity() { }

		protected BaseActivity(int contentResourceId)
		{
			this.contentResourceId = contentResourceId;
		}

		protected override void OnCreate(Bundle bundle)
		{
			try
			{
				base.OnCreate(bundle);
				if (contentResourceId >= 0)
				{
					SetContentView(contentResourceId);
				}
				DoOnCreate(bundle);
			}
			catch (Exception e)
			{
				e.LogToConsole();
				throw;
			}
		}

		protected override void OnStart()
		{
			try
			{
				base.OnStart();
				DoOnStart();
				SubscribeToLayoutEvents();
				SubscribeToViewModelEvents(ViewModel);
			}
			catch (Exception e)
			{
				e.LogToConsole();
				throw;
			}
		}

		protected override void OnPause()
		{
			try
			{
				base.OnPause();
				DoOnPause();
			}
			catch (Exception e)
			{
				e.LogToConsole();
				throw;
			}
			base.OnPause();
		}

		protected override void OnResume()
		{
			try
			{
				base.OnResume();
				this.HideKeyboard();
				DoOnResume();
			}
			catch (Exception e)
			{
				e.LogToConsole();
				throw;
			}
		}

		protected override void OnStop()
		{
			try
			{
				base.OnStop();
				DoOnStop();
				UnSubscribeFromLayoutEvents();
				UnSubscribeFromViewModelEvents(ViewModel);
			}
			catch (Exception e)
			{
				e.LogToConsole();
				throw;
			}
		}

		protected override void OnDestroy()
		{
			try
			{
				DoOnDestroy();
				base.OnDestroy();
			}
			catch (Exception e)
			{
				e.LogToConsole();
				throw;
			}
		}

		public override void OnBackPressed()
		{
			try
			{
				this.HideKeyboard();
				base.OnBackPressed();
			}
			catch (Exception e)
			{
				e.LogToConsole();
				throw;
			}
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			try
			{
				DoOnSaveInstanceState(outState);
			}
			catch (Exception e)
			{
				e.LogToConsole();
				throw;
			}
		}

		protected virtual void DoOnCreate(Bundle bundle) { }
		protected virtual void DoOnStart() { }
		protected virtual void DoOnPause() { }
		protected virtual void DoOnResume() { }
		protected virtual void DoOnStop() { }
		protected virtual void DoOnDestroy() { }
		protected virtual void DoOnSaveInstanceState(Bundle outState) { }
		protected virtual void SubscribeToLayoutEvents() { }
		protected virtual void SubscribeToViewModelEvents(TViewModel viewModel) { }
		protected virtual void UnSubscribeFromLayoutEvents() { }
		protected virtual void UnSubscribeFromViewModelEvents(TViewModel viewModel) { }
	}
}
