using System.Threading.Tasks;
using Rozklad.Mobile.Core.DeviceInformation;

namespace Rozklad.Mobile.Core.PlatformServices
{
	public interface IDeviceInformation
	{
		Task<Platform> GetCurrentPlatformAsync();
		Task<DeviceInformationData> GetDeviceInformationAsync();
		Task<bool> HasInternetConnectionAsync();
	}
}
