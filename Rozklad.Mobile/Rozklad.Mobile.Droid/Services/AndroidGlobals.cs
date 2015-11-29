using Android.App;
using Android.Content;
using Cirrious.CrossCore.Droid.Platform;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Droid.Services
{
	public class AndroidGlobals : IAndroidGlobals
	{
		private readonly string personalStoragePath;
		private readonly Context applicationCotnext;
		private readonly IMvxAndroidCurrentTopActivity mvxAndroidCurrentTopActivity;

		public AndroidGlobals(IMvxAndroidCurrentTopActivity mvxAndroidCurrentTopActivity)
		{
			mvxAndroidCurrentTopActivity.ThrowIfNull(nameof(mvxAndroidCurrentTopActivity));

			this.mvxAndroidCurrentTopActivity = mvxAndroidCurrentTopActivity;

			applicationCotnext = Application.Context;
			personalStoragePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
		}

		public Context ApplicationContext => applicationCotnext;
		public Activity TopActivity => mvxAndroidCurrentTopActivity.Activity;
		public Context TopActivityContext => mvxAndroidCurrentTopActivity.Activity;
		public Dialog Spinner { get; set; }
		public string PersonalStoragePath => personalStoragePath;
	}
}