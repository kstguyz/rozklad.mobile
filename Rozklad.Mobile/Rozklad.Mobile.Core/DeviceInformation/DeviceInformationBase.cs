using System.Threading.Tasks;
using Rozklad.Mobile.Core.PlatformServices;

namespace Rozklad.Mobile.Core.DeviceInformation
{
	public abstract class DeviceInformationBase : IDeviceInformation
	{
		private DeviceInformationData deviceInformationData;

		public async Task<Platform> GetCurrentPlatformAsync()
		{
			var deviceInfo = await GetDeviceInformationAsync();
			var platform = deviceInfo.Platform;

			return await Task.FromResult(platform);
		}

		public async Task<DeviceInformationData> GetDeviceInformationAsync()
		{
			if (deviceInformationData == null)
			{
				deviceInformationData = GetDeviceInformation();
			}

			return await Task.FromResult(deviceInformationData);
		}

		protected abstract DeviceInformationData GetDeviceInformation();

		public abstract Task<bool> HasInternetConnectionAsync();
	}
}
