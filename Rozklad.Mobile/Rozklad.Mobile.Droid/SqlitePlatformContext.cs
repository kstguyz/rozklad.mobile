using System;
using System.IO;
using Rozklad.Mobile.Core.DataBase;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;

namespace Rozklad.Mobile.Droid
{
	public class SqlitePlatformContext : SqlitePlatformContextBase
	{
		public override ISQLitePlatform Platform => new SQLitePlatformAndroid();
		public override string PlatformDatabaseFolderPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DataBaseName);
	}
}