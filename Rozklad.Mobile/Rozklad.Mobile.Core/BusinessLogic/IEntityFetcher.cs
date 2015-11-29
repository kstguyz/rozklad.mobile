using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.BusinessLogic.Converters;
using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;
using Rozklad.Mobile.Core.Repositories.Local;
using Rozklad.Mobile.Core.Repositories.Remote;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public interface IEntityFetcher
	{
		Task<TEntity> FetchAndCacheAsync<TEntity, TWebEntity>(int id,
															  IRemoteRepositoryAsync<TWebEntity> remoteRepository,
															  ILocalRepositoryAsync<TEntity> localRepository,
															  IEntityConverter<TEntity, TWebEntity> converter)
			where TEntity : EntityBase, IEntity, new()
			where TWebEntity : ResponseEntityBase;

		Task<IEnumerable<TEntity>> FetchAndCacheAsync<TEntity, TWebEntity>(IEnumerable<int> ids,
																		   IRemoteRepositoryAsync<TWebEntity> remoteRepository,
																		   ILocalRepositoryAsync<TEntity> localRepository,
																		   IEntityConverter<TEntity, TWebEntity> converter)
			where TEntity : EntityBase, IEntity, new()
			where TWebEntity : ResponseEntityBase;
	}
}
