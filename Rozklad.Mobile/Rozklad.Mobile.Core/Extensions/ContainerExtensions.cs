using System;
using Cirrious.CrossCore;

namespace Rozklad.Mobile.Core.Extensions
{
	public static class ContainerExtensions
	{
		public static T Resolve<T>() where T : class
		{
			try
			{
				return Mvx.Resolve<T>();
			}
			catch (Exception ex)
			{
				ex.LogToConsole();
				return default(T);
			}
		}
	}
}
