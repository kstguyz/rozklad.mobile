using Rozklad.Mobile.Core.Extensions;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;

namespace Rozklad.Mobile.Core.DataBase
{
	/// <summary>
	/// Produce one connection for all requests
	/// </summary>
	public class SingletonConnectionFactory : IConnectionFactory
	{
		private readonly object asyncConnectionFactoryLock = new object();
		private readonly ISqlitePlatformContext sqlitePlatformContext;

		private volatile IConnectionAsync asyncConnection;

		public SingletonConnectionFactory(ISqlitePlatformContext sqlitePlatformContext)
		{
			sqlitePlatformContext.ThrowIfNull(nameof(sqlitePlatformContext));

			this.sqlitePlatformContext = sqlitePlatformContext;
		}

		public void DropConnection()
		{
			if (asyncConnection == null)
				return;

			lock (asyncConnectionFactoryLock)
			{
				asyncConnection = null;
			}
		}

		public IConnectionAsync ProduceConnection()
		{
			if (asyncConnection != null)
				return asyncConnection;

			lock (asyncConnectionFactoryLock)
			{
				if (asyncConnection != null)
					return asyncConnection;

				var sqLiteAsyncConnection = ProduceSqLiteAsyncConnection();
				asyncConnection = new SqliteConnectionWrapperAsync(sqLiteAsyncConnection);
			}

			return asyncConnection;
		}

		private SQLiteAsyncConnection ProduceSqLiteAsyncConnection()
		{
			var sqLiteAsyncConnection = new SQLiteAsyncConnection(GetSqliteConnection);

			return sqLiteAsyncConnection;
		}

		private SQLiteConnectionWithLock GetSqliteConnection()
		{
			var platform = GetSqLitePlatform();
			var connectionString = ProduceConnectionString();
			var sqLiteConnection = new SQLiteConnectionWithLock(platform, connectionString);

			return sqLiteConnection;
		}

		private SQLiteConnectionString ProduceConnectionString()
		{
			var path = GetDbPath();
			var storeDateTimeAsTicks = StoreDateTimeAsTicks();
			var connectionString = new SQLiteConnectionString(path, storeDateTimeAsTicks);

			return connectionString;
		}

		protected virtual string GetDbPath()
		{
			return sqlitePlatformContext.PlatformDatabaseFolderPath;
		}

		protected virtual ISQLitePlatform GetSqLitePlatform()
		{
			return sqlitePlatformContext.Platform;
		}

		protected virtual bool StoreDateTimeAsTicks()
		{
			return true;
		}
	}
}
