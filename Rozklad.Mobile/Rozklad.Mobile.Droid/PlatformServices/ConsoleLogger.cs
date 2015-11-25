using System;
using Rozklad.Mobile.Core.Extensions;
using Rozklad.Mobile.Core.PlatformServices;

namespace Rozklad.Mobile.Droid.PlatformServices
{
	public class ConsoleLogger : IConsoleLogger
	{
		private readonly string tag;

		public ConsoleLogger(string tag)
		{
			tag.ThrowIfNullOrEmpty("tag");

			this.tag = tag;
		}

		public void Exception(Exception e)
		{
			var message = e.ToString();
			Android.Util.Log.Error(tag, message);
		}

		public void Error(string message)
		{
			Android.Util.Log.Error(tag, message);
		}

		public void Trace(string message)
		{
			Android.Util.Log.Debug(tag, message);
		}

		public void Warning(string message)
		{
			Android.Util.Log.Warn(tag, message);
		}
	}
}
