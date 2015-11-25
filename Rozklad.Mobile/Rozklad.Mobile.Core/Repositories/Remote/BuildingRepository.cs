using Rozklad.Mobile.Core.WebService.DataContracts.Response;
using Rozklad.Mobile.Core.WebService.Rest;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public class BuildingRepository : RemoteRepositoryAsyncBase<Building>, IBuildingRepository
	{
		public BuildingRepository(IRestServiceClient restServiceClient, string url) 
			: base(restServiceClient, url)
		{ }
	}
}
