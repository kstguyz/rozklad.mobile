using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.DataBase;

namespace Rozklad.Mobile.Core.LocalRepositories
{
	public interface ILocalRepositoryAsync<TEntity> : IDisposable
		where TEntity : class, IEntity, new()
	{
		/// <summary>
		/// Insert item
		/// </summary>
		/// <param name="item">Item to insert</param>
		Task<int> CreateAsync(TEntity item);

		/// <summary>
		/// Insert items
		/// </summary>
		/// <param name="items">Items to insert</param>
		Task<int> CreateAllAsync(IEnumerable<TEntity> items);

		/// <summary>
		/// Read item by key
		/// </summary>
		/// <param name="id">Key</param>
		Task<TEntity> ReadAsync(int id);

		/// <summary>
		/// Read all items from table
		/// </summary>
		Task<IEnumerable<TEntity>> ReadAllAsync();

		/// <summary>
		/// Update item
		/// </summary>
		/// <param name="item">Item to update</param>
		/// <returns></returns>
		Task<int> UpdateAsync(TEntity item);

		/// <summary>
		/// Update items
		/// </summary>
		/// <param name="items">Items to update</param>
		Task<int> UpdateAllAsync(IEnumerable<TEntity> items);

		/// <summary>
		/// Delete item
		/// </summary>
		/// <param name="item">Item to delete</param>
		Task<int> DeleteAsync(TEntity item);

		/// <summary>
		/// Delete all items from table
		/// </summary>
		Task<int> DeleteAllAsync();

		/// <summary>
		/// Drop table
		/// </summary>
		Task DropTable();

		/// <summary>
		/// Create table
		/// </summary>
		Task CreateTable();
	}
}
