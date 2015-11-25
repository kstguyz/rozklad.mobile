using System;
using Cirrious.CrossCore;
using Rozklad.Mobile.Core.PlatformServices;

namespace Rozklad.Mobile.Core.Extensions
{
	public static class ConsoleLogger
	{
		private static IConsoleLogger logger;
		private static IConsoleLogger Logger => logger ?? (logger = Mvx.Resolve<IConsoleLogger>());

		public static void LogToConsole(this Exception e)
		{
			SafeExecute(() => Logger?.Exception(e));
		}

		public static void Exception(Exception e)
		{
			SafeExecute(() => Logger?.Exception(e));
		}

		public static void Error(string message)
		{
			SafeExecute(() => Logger?.Error(message));
		}

		public static void Trace(string message)
		{
			SafeExecute(() => Logger?.Trace(message));
		}

		public static void Warning(string message)
		{
			SafeExecute(() => Logger?.Warning(message));
		}

		private static void SafeExecute(Action logAction)
		{
			try
			{
				logAction();
			}
			catch (Exception)
			{
				// what else can we do?
			}
		}
	}
}
