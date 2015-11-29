using System;
using System.Threading.Tasks;
using Android.App;
using Android.Net;
using Cirrious.CrossCore.Droid.Platform;
using Rozklad.Mobile.Core.DeviceInformation;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Droid.PlatformServices.DeviceInformation
{
	public class DeviceInformation : DeviceInformationBase
	{
		private readonly IMvxAndroidCurrentTopActivity mvxAndroidCurrentTopActivity = null;

		public DeviceInformation(IMvxAndroidCurrentTopActivity mvxAndroidCurrentTopActivity)
		{
			mvxAndroidCurrentTopActivity.ThrowIfNull(nameof(mvxAndroidCurrentTopActivity));

			this.mvxAndroidCurrentTopActivity = mvxAndroidCurrentTopActivity;
		}

		protected Activity TopActivity => mvxAndroidCurrentTopActivity?.Activity;

		protected override DeviceInformationData GetDeviceInformation()
		{
			var info = new DeviceInformationDataDroid();

			return info;
		}

		public override async Task<bool> HasInternetConnectionAsync()
		{
			var activity = mvxAndroidCurrentTopActivity?.Activity;
			if (activity == null)
			{
				throw new NullReferenceException(
					"Activity can't be null. ITopActivity must be implemented and registered in IoC container.");
			}

			var connectivityManager =
				(ConnectivityManager) activity.GetSystemService(Android.Content.Context.ConnectivityService);
			var activeConnection = connectivityManager.ActiveNetworkInfo;
			var hasConnection = activeConnection != null && activeConnection.IsConnected;

			return await Task.FromResult(hasConnection);
		}
	}
}
