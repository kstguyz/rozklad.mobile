using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Configuration;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;
using Rozklad.Mobile.Core.WebService.Rest;
using Room = Rozklad.Mobile.Core.WebService.DataContracts.Response.Room;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public class RoomRepository : RemoteRepositoryAsyncBase<Room>, IRoomRepository
	{
	    public RoomRepository(IRestServiceClient restServiceClient, string url) 
			: base(restServiceClient, url)
	    { }

        public async Task<PageResults<Room>> FilterAsync(string name = "", int? buildingId = null)
        {
	        var parameters = ProduceParameters(name, buildingId);
			var result = await GetFilteredAsync(parameters);

			return result;
		}

		public async Task<IEnumerable<Room>> FilterAllAsync(string name = "", int? buildingId = null)
		{
			var parameters = ProduceParameters(name, buildingId);
			var result = await GetAllFilteredAsync(parameters);

			return result;
		}

		private static List<KeyValuePair<string, object>> ProduceParameters(string name = "", int? buildingId = null)
		{
			var parameters = new List<KeyValuePair<string, object>>();
			if (string.IsNullOrEmpty(name) == false)
			{
				parameters.Add(GetNameParameter(name));
			}
			if (buildingId.HasValue == true)
			{
				parameters.Add(GetBuildingParameter(buildingId.Value));
			}

			return parameters;
		}

		private static KeyValuePair<string, object> GetBuildingParameter(int buildingId)
	    {
		    var keyValuePair = new KeyValuePair<string, object>(Parameters.Room.Building, buildingId);

		    return keyValuePair;
	    }

		private static KeyValuePair<string, object> GetNameParameter(string name)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Room.Name, name);

			return keyValuePair;
		}
	}
}
