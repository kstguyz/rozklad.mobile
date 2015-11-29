using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Rozklad.Mobile.Core.Extensions;
using Rozklad.Mobile.Core.PlatformServices;

namespace Rozklad.Mobile.Droid.PlatformServices
{
	public class Spinner : ISpinner
	{
		private readonly object stopSpinnerLock = new object();
		private readonly object startSpinnerLock = new object();
		private readonly IAndroidGlobals androidGlobals;

		public Spinner(IAndroidGlobals androidGlobals)
		{
			androidGlobals.ThrowIfNull(nameof(androidGlobals));

			this.androidGlobals = androidGlobals;
		}

		public void Start()
		{
			lock (startSpinnerLock)
			{
				Stop();

				var context = androidGlobals.TopActivityContext;
				var loadingDialog = new Dialog(context);
				loadingDialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
				loadingDialog.SetCancelable(false);
				loadingDialog.SetCanceledOnTouchOutside(false);
				var window = loadingDialog.Window;
				window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
				window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));

				var progress =
					new ProgressBar(context)
					{
						LayoutParameters =
							new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent),
						Indeterminate = true
					};
				loadingDialog.AddContentView(progress, progress.LayoutParameters);
				loadingDialog.Show();

				androidGlobals.Spinner = loadingDialog;
			}
		}

		public void Stop()
		{
			if (androidGlobals.Spinner == null)
				return;

			lock (stopSpinnerLock)
			{
				androidGlobals.Spinner?.Hide();
			}
		}
	}
}