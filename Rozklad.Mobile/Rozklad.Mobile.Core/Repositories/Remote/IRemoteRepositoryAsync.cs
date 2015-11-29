using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.WebService;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public interface IRemoteRepositoryAsync<TDataTransferObject> 
		where TDataTransferObject : WebService.DataContracts.Response.ResponseEntityBase
	{
		Task<TDataTransferObject> DeleteAsync(IServiceClientRequest request = null);
		Task<TDataTransferObject> GetAsync(IServiceClientRequest request = null);
		Task<TDataTransferObject> GetByIdAsync(int id);
		Task<IEnumerable<TDataTransferObject>> GetAllAsync();
        Task<WebService.DataContracts.Response.PageResults<TDataTransferObject>> GetPageAsync(int page, int limit);
		Task<TDataTransferObject> PostAsync(IServiceClientRequest request = null);
		Task<byte[]> PostBytesAsync(IServiceClientRequest request = null);
		Task<TDataTransferObject> PutAsync(IServiceClientRequest request = null);
	}
}