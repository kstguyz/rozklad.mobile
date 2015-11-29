using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Provider;
using Rozklad.Mobile.Core.DeviceInformation;

namespace Rozklad.Mobile.Droid.PlatformServices.DeviceInformation
{
	class DeviceInformationDataDroid : DeviceInformationData
	{
		public override string DeviceModel => Build.Model;

		public override string DeviceType => DeviceTypeDefinition.Android.ToString();

		public override string DeviceUDID => Settings.Secure.GetString(Application.Context.ContentResolver, Settings.Secure.AndroidId);

		public override bool IsTablet => Application.Context.Resources.Configuration.ScreenLayout.HasFlag(ScreenLayout.SizeLarge);

		public override Platform Platform => Platform.Android;
	}
}
