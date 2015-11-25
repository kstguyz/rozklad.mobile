using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Extensions;
using SQLite.Net.Async;

namespace Rozklad.Mobile.Core.DataBase
{
	public class SqliteConnectionWrapperAsync : IConnectionAsync
	{
		private SQLiteAsyncConnection connection;

		public SqliteConnectionWrapperAsync(SQLiteAsyncConnection connection)
		{
			connection.ThrowIfNull(nameof(connection));

			this.connection = connection;
		}

		public void Dispose()
		{
			connection = null;
		}

		public async Task<int> DropTableAsync<TEntity>() where TEntity : class, IEntity
		{
			return await DropTableAsync<TEntity>(CancellationToken.None);
		}

		public async Task<int> DropTableAsync<TEntity>(CancellationToken ct) where TEntity : class, IEntity
		{
			return await connection.DropTableAsync<TEntity>(ct);
		}

		public async Task<int> CreateTableAsync<TEntity>() where TEntity : class, IEntity
		{
			return await CreateTableAsync<TEntity>(CancellationToken.None);
		}

		public async Task<int> CreateTableAsync<TEntity>(CancellationToken ct) where TEntity : class, IEntity
		{
			var tableResult = await connection.CreateTableAsync<TEntity>(ct);

			try
			{
				var typeResult = tableResult.Results[typeof (TEntity)];

				return typeResult;
			}
			catch (Exception e)
			{
				e.LogToConsole();

				return -1;
			}
		}

		public async Task<TEntity> GetAsync<TEntity>(object pk) 
			where TEntity : class, IEntity
		{
			return await GetAsync<TEntity>(pk, CancellationToken.None);
		}

		public async Task<TEntity> GetAsync<TEntity>(object pk, CancellationToken ct) 
			where TEntity : class, IEntity
		{
			return await connection.GetAsync<TEntity>(pk, ct);
		}

		public async Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) 
			where TEntity : class, IEntity
		{
			return await GetAsync(predicate, CancellationToken.None);
		}

		public async Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken ct)
			where TEntity : class, IEntity
		{
			return await connection.Table<TEntity>()
			                       .Where(predicate)
			                       .FirstOrDefaultAsync(ct);
		}

		public async Task<IEnumerable<TEntity>> TableAsync<TEntity>() 
			where TEntity : class, IEntity
		{
			return await TableAsync<TEntity>(CancellationToken.None);
		}

		public async Task<IEnumerable<TEntity>> TableAsync<TEntity>(CancellationToken ct) 
			where TEntity : class, IEntity
		{
			return await connection.Table<TEntity>().ToListAsync(ct);
		}

		public async Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects) 
			where TEntity : class, IEntity
		{
			return await InsertAllAsync(objects, CancellationToken.None);
		}

		public async Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct)
			where TEntity : class, IEntity
		{
			return await connection.InsertAllAsync(objects, ct);
		}

		public async Task<int> InsertAsync<TEntity>(TEntity obj) 
			where TEntity : class, IEntity
		{
			return await InsertAsync(obj, CancellationToken.None);
		}

		public async Task<int> InsertAsync<TEntity>(TEntity obj, CancellationToken ct) 
			where TEntity : class, IEntity
		{
			return await connection.InsertAsync(obj, ct);
		}

		public async Task<int> UpdateAsync<TEntity>(TEntity obj) 
			where TEntity : class, IEntity
		{
			return await UpdateAsync(obj, CancellationToken.None);
		}

		public async Task<int> UpdateAsync<TEntity>(TEntity obj, CancellationToken ct) 
			where TEntity : class, IEntity
		{
			return await connection.UpdateAsync(obj, ct);
		}

		public async Task<int> UpdateAllAsync<TEntity>(IEnumerable<TEntity> objects) 
			where TEntity : class, IEntity
		{
			return await UpdateAllAsync(objects, CancellationToken.None);
		}

		public async Task<int> UpdateAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct)
			where TEntity : class, IEntity
		{
			return await connection.UpdateAllAsync(objects, ct);
		}

		public async Task<int> DeleteAsync<TEntity>(TEntity objectToDelete) 
			where TEntity : class, IEntity
		{
			return await connection.DeleteAsync(objectToDelete, CancellationToken.None);
		}

		public async Task<int> DeleteAsync<TEntity>(TEntity objectToDelete, CancellationToken ct)
			where TEntity : class, IEntity
		{
			return await connection.DeleteAsync(objectToDelete, ct);
		}

		public async Task<int> DeleteAsync<TEntity>(object primaryKey) 
			where TEntity : class, IEntity
		{
			return await DeleteAsync<TEntity>(primaryKey, CancellationToken.None);
		}

		public async Task<int> DeleteAsync<TEntity>(object primaryKey, CancellationToken ct) 
			where TEntity : class, IEntity
		{
			return await connection.DeleteAsync<TEntity>(primaryKey, ct);
		}

		public async Task<int> DeleteAllAsync<TEntity>() 
			where TEntity : class, IEntity
		{
			return await DeleteAllAsync<TEntity>(CancellationToken.None);
		}

		public async Task<int> DeleteAllAsync<TEntity>(CancellationToken ct) 
			where TEntity : class, IEntity
		{
			return await connection.DeleteAllAsync<TEntity>(ct);
		}

		public async Task<int> DeleteAllAsync<TEntity>(IEnumerable<TEntity> objects) 
			where TEntity : class, IEntity
		{
			return await DeleteAllAsync(objects, CancellationToken.None);
		}

		public async Task<int> DeleteAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct)
			where TEntity : class, IEntity
		{
			var num = 0;
			foreach (var entity in objects)
			{
				var result = await DeleteAsync(entity, ct);
				num += result;
				ct.ThrowIfCancellationRequested();
			}

			return num;
		}
	}
}
