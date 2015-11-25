using SQLite.Net.Interop;

namespace Rozklad.Mobile.Core.DataBase
{
	public interface ISqlitePlatformContext
	{
		ISQLitePlatform Platform { get; }
		string PlatformDatabaseFolderPath { get; }
		string DataBaseName { get; set; }
	}
}
