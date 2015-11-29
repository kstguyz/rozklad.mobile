using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core.Repositories.Local
{
	public abstract class LocalRepositoryAsyncBase<TEntity> : DataBaseConnectionAsync, ILocalRepositoryAsync<TEntity>
		where TEntity : class, IEntity, new()
	{
		private const int FaultValue = -1;
		protected LocalRepositoryAsyncBase(IConnectionFactory factory)
			: base(factory)
		{ }

		/// <summary>
		/// Insert item
		/// </summary>
		/// <param name="item">Item to insert</param>
		public async Task<int> CreateAsync(TEntity item)
		{
			try
			{
				return await DbConnection.InsertAsync(item);
			}
			catch (Exception e)
			{
				e.LogToConsole();
				return FaultValue;
			}
		}

		/// <summary>
		/// Insert items
		/// </summary>
		/// <param name="items">Items to insert</param>
		public async Task<int> CreateAllAsync(IEnumerable<TEntity> items)
		{
			try
			{
				return await DbConnection.InsertAllAsync(items);
			}
			catch (Exception e)
			{
				e.LogToConsole();
				return FaultValue;
			}
		}

		/// <summary>
		/// Read item by key
		/// </summary>
		/// <param name="id">Key</param>
		public async Task<TEntity> ReadAsync(int id)
		{
			try
			{
				return await DbConnection.GetAsync<TEntity>(id);
			}
			catch (Exception e)
			{
				e.LogToConsole();
				return default(TEntity);
			}
		}

		/// <summary>
		/// Read all items from table
		/// </summary>
		public async Task<IEnumerable<TEntity>> ReadAllAsync()
		{
			try
			{
				return await DbConnection.TableAsync<TEntity>();
			}
			catch (Exception e)
			{
				e.LogToConsole();

				return new TEntity[0];
			}
		}

		/// <summary>
		/// Update item
		/// </summary>
		/// <param name="item">Item to update</param>
		/// <returns></returns>
		public async Task<int> UpdateAsync(TEntity item)
		{
			try
			{
				return await DbConnection.UpdateAsync(item);
			}
			catch (Exception e)
			{
				e.LogToConsole();
				return FaultValue;
			}
		}

		/// <summary>
		/// Update items
		/// </summary>
		/// <param name="items">Items to update</param>
		public async Task<int> UpdateAllAsync(IEnumerable<TEntity> items)
		{
			try
			{
				return await DbConnection.UpdateAllAsync(items);
			}
			catch (Exception e)
			{
				e.LogToConsole();
				return FaultValue;
			}
		}

		/// <summary>
		/// Delete item
		/// </summary>
		/// <param name="item">Item to delete</param>
		public async Task<int> DeleteAsync(TEntity item)
		{
			try
			{
				return await DbConnection.DeleteAsync(item);
			}
			catch (Exception e)
			{
				e.LogToConsole();
				return FaultValue;
			}
		}

		/// <summary>
		/// Delete all items from table
		/// </summary>
		public async Task<int> DeleteAllAsync()
		{
			try
			{
				return await DbConnection.DeleteAllAsync<TEntity>();
			}
			catch (Exception e)
			{
				e.LogToConsole();
				return FaultValue;
			}
		}

		/// <summary>
		/// Drop table
		/// </summary>
		public async Task DropTableAsync()
		{
			try
			{
				await DbConnection.DropTableAsync<TEntity>();
			}
			catch (Exception e)
			{
				e.LogToConsole();
				throw new CannotDropTableException(typeof(TEntity), e);
			}
		}

		/// <summary>
		/// Create table
		/// </summary>
		public async Task CreateTableAsync()
		{
			try
			{
				await DbConnection.CreateTableAsync<TEntity>();
			}
			catch (Exception e)
			{
				e.LogToConsole();
				throw new CannotCreateTableException(typeof(TEntity), e);
			}
		}
	}
}
