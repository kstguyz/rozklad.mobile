namespace Rozklad.Mobile.Core.DeviceInformation
{
	public abstract class DeviceInformationData
	{
		protected enum DeviceTypeDefinition
		{
			Android,
			iPad,
			iPhone,
			WP
		}

		/// <summary>
		/// Platform Name (IOS, Android, WindowsPhone).
		/// </summary>
		public abstract Platform Platform { get; }

		/// <summary>
		/// Device type (Android, iPad, iPhone, WP) 
		/// The value is as expected by DMI services.
		/// </summary>
		public abstract string DeviceType { get; }

		/// <summary>
		/// Device model (Apple-iPhone6C1/1202.411...)
		/// </summary>
		public abstract string DeviceModel { get; }

		/// <summary>
		/// For iPad, android, windows tablets should be true.
		/// </summary>
		public abstract bool IsTablet { get; }

		/// <summary>
		/// Device UDID.
		/// </summary>
		public abstract string DeviceUDID { get; }

		public override string ToString()
		{
			return $"[DeviceInformationData: Platform={Platform}, DeviceType={DeviceType}, DeviceModel={DeviceModel}, IsTablet={IsTablet}, DeviceUDID={DeviceUDID}]";
		}
	}
}
