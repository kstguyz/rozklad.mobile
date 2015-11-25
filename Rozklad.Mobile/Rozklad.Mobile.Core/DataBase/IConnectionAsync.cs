using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Rozklad.Mobile.Core.DataBase
{
	public interface IConnectionAsync : IDisposable
	{
		Task<int> DropTableAsync<TEntity>() where TEntity : class, IEntity;
		Task<int> DropTableAsync<TEntity>(CancellationToken ct) where TEntity : class, IEntity;

		Task<int> CreateTableAsync<TEntity>() where TEntity : class, IEntity;
		Task<int> CreateTableAsync<TEntity>(CancellationToken ct) where TEntity : class, IEntity;

		Task<TEntity> GetAsync<TEntity>(object pk) where TEntity : class, IEntity;
		Task<TEntity> GetAsync<TEntity>(object pk, CancellationToken ct) where TEntity : class, IEntity;

		Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;
		Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken ct) where TEntity : class, IEntity;

		Task<IEnumerable<TEntity>> TableAsync<TEntity>() where TEntity : class, IEntity;
		Task<IEnumerable<TEntity>> TableAsync<TEntity>(CancellationToken ct) where TEntity : class, IEntity;

		Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects) where TEntity : class, IEntity;
		Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct) where TEntity : class, IEntity;

		Task<int> InsertAsync<TEntity>(TEntity obj) where TEntity : class, IEntity;
		Task<int> InsertAsync<TEntity>(TEntity obj, CancellationToken ct) where TEntity : class, IEntity;

		Task<int> UpdateAsync<TEntity>(TEntity obj) where TEntity : class, IEntity;
		Task<int> UpdateAsync<TEntity>(TEntity obj, CancellationToken ct) where TEntity : class, IEntity;

		Task<int> UpdateAllAsync<TEntity>(IEnumerable<TEntity> objects) where TEntity : class, IEntity;
		Task<int> UpdateAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct) where TEntity : class, IEntity;

		Task<int> DeleteAsync<TEntity>(TEntity objectToDelete) where TEntity : class, IEntity;
		Task<int> DeleteAsync<TEntity>(TEntity objectToDelete, CancellationToken ct) where TEntity : class, IEntity;

		Task<int> DeleteAsync<TEntity>(object primaryKey) where TEntity : class, IEntity;
		Task<int> DeleteAsync<TEntity>(object primaryKey, CancellationToken ct) where TEntity : class, IEntity;

		Task<int> DeleteAllAsync<TEntity>() where TEntity : class, IEntity;
		Task<int> DeleteAllAsync<TEntity>(CancellationToken ct) where TEntity : class, IEntity;

		Task<int> DeleteAllAsync<TEntity>(IEnumerable<TEntity> objects) where TEntity : class, IEntity;
		Task<int> DeleteAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct) where TEntity : class, IEntity;
	}
}
