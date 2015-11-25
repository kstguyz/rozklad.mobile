using System.Threading.Tasks;
using Rozklad.Mobile.Core.WebService;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public interface IRemoteRepositoryAsync<TDataTransferObject> where TDataTransferObject : ResponseEntityBase
	{
		Task<TDataTransferObject> DeleteAsync(IServiceClientRequest request = null);
		Task<TDataTransferObject> GetAsync(IServiceClientRequest request = null);
		Task<TDataTransferObject> GetByIdAsync(int id);
		Task<PageResults<TDataTransferObject>> GetPageAsync(int page, int limit);
		Task<TDataTransferObject> PostAsync(IServiceClientRequest request = null);
		Task<byte[]> PostBytesAsync(IServiceClientRequest request = null);
		Task<TDataTransferObject> PutAsync(IServiceClientRequest request = null);
	}
}