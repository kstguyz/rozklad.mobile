using System;

namespace Rozklad.Mobile.Core.Extensions
{
	public static class ThrowExtensions
	{
		public static void ThrowIfNullOrEmpty(this string str, string paramName)
		{
			if (string.IsNullOrEmpty(str))
				throw new ArgumentNullException(paramName);
		}

		public static void ThrowIfNullOrEmpty(this string str, string paramName, string message)
		{
			if (string.IsNullOrEmpty(str))
				throw new ArgumentNullException(paramName, message);
		}

		public static void ThrowIfNullOrEmpty(this string str, string message, Exception innerException)
		{
			if (string.IsNullOrEmpty(str))
				throw new ArgumentNullException(message, innerException);
		}

		public static void ThrowIfNull(this object o, string paramName)
		{
			if (o == null)
				throw new ArgumentNullException(paramName);
		}

		public static void ThrowIfNull(this object o, string paramName, string message)
		{
			if (o == null)
				throw new ArgumentNullException(paramName, message);
		}

		public static void ThrowIfNull(this object o, string message, Exception innerException)
		{
			if (o == null)
				throw new ArgumentNullException(message, innerException);
		}
	}
}
