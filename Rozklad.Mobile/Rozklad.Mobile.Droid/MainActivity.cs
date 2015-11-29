using Android.App;
using Android.Widget;
using Android.OS;

namespace Rozklad.Mobile.Droid
{
	[Activity(Label = "Rozklad.Mobile.Droid", Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
		}
	}
}

