using SQLite.Net.Interop;

namespace Rozklad.Mobile.Core.DataBase
{
	public abstract class SqlitePlatformContextBase : ISqlitePlatformContext
	{
		protected SqlitePlatformContextBase()
		{
			DataBaseName = "DataBase.db";
		}
		public string DataBaseName { get; set; }

		public abstract string PlatformDatabaseFolderPath { get; }
		public abstract ISQLitePlatform Platform { get; }

	}
}
