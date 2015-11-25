using System;

namespace Rozklad.Mobile.Core.PlatformServices
{
	public interface IConsoleLogger
	{
		void Error(string message);
		void Exception(Exception e);
		void Trace(string message);
		void Warning(string message);
	}
}
