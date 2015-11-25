using Rozklad.Mobile.Core.WebService.DataContracts.Response;
using Rozklad.Mobile.Core.WebService.Rest;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public class DisciplineRepository : RemoteRepositoryAsyncBase<Discipline>, IDisciplineRepository
	{
		public DisciplineRepository(IRestServiceClient restServiceClient, string url)
			: base(restServiceClient, url)
		{ }
	}
}