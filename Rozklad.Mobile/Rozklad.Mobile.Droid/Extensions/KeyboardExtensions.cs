using Android.App;
using Android.OS;
using Android.Views.InputMethods;

namespace Rozklad.Mobile.Droid.Extensions
{
	public static class KeyboardExtensions
	{
		public static void HideKeyboard(this Fragment fragment)
		{
			HideKeyboard(fragment.Activity);
		}

		public static void HideKeyboard(this Activity activity)
		{
			var currentFocus = activity.CurrentFocus;
			if (currentFocus == null)
				return;

			Hide(currentFocus.WindowToken, HideSoftInputFlags.None);
		}

		private static void Hide(IBinder windowToken, HideSoftInputFlags hideSoftInputFlags)
		{
			((InputMethodManager)Application.Context.GetSystemService("input_method")).HideSoftInputFromWindow(windowToken, hideSoftInputFlags);
		}
	}
}
