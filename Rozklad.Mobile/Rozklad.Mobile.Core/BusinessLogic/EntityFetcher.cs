using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.BusinessLogic.Exceptions;
using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public class EntityFetcher : IEntityFetcher
	{
		public async Task<TEntity> FetchAndCacheAsync<TEntity, TWebEntity>(int id,
																		   Repositories.Remote.IRemoteRepositoryAsync<TWebEntity> remoteRepository,
																		   Repositories.Local.ILocalRepositoryAsync<TEntity> localRepository,
																		   Converters.IEntityConverter<TEntity, TWebEntity> converter)
			where TEntity : EntityBase, IEntity, new()
			where TWebEntity : WebService.DataContracts.Response.ResponseEntityBase
		{
			try
			{
				var entity = await localRepository.ReadAsync(id);
				if (entity != null)
					return entity;

				var webEntity = await remoteRepository.GetByIdAsync(id);
				entity = converter.Convert(webEntity);

				if (entity == null)
					throw new EntityNotFoundException<TEntity>(id);

				await localRepository.CreateAsync(entity);

				return entity;
			}
			catch (EntityNotFoundException<TEntity>)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new EntityNotFoundException<TEntity>(id, e);
			}
		}

		public async Task<IEnumerable<TEntity>> FetchAndCacheAsync<TEntity, TWebEntity>(IEnumerable<int> ids,
																						Repositories.Remote.IRemoteRepositoryAsync<TWebEntity> remoteRepository,
																						Repositories.Local.ILocalRepositoryAsync<TEntity> localRepository,
																						Converters.IEntityConverter<TEntity, TWebEntity> converter)
			where TEntity : EntityBase, IEntity, new()
			where TWebEntity : WebService.DataContracts.Response.ResponseEntityBase
		{
			var count = ids.Count();
			var entities = new List<TEntity>(count);
			foreach (var id in ids)
			{
				var entity = await FetchAndCacheAsync(id, remoteRepository, localRepository, converter);
				entities.Add(entity);
			}

			return entities;
		}
	}
}
