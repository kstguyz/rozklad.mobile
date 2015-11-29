using Android.App;
using Android.Content;

namespace Rozklad.Mobile.Droid.Services
{
	public interface IAndroidGlobals
	{
		Context ApplicationContext { get; }
		Activity TopActivity { get; }
		Context TopActivityContext { get; }
		string PersonalStoragePath { get; }
		Dialog Spinner { get; set; }
	}
}