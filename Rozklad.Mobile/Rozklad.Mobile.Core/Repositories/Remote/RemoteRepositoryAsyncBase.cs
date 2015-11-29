using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Extensions;
using Rozklad.Mobile.Core.WebService;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;
using Rozklad.Mobile.Core.WebService.Exceptions;
using Rozklad.Mobile.Core.WebService.Rest;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public abstract class RemoteRepositoryAsyncBase<TDataTransferObject> : WebServiceConnectionAsync, IRemoteRepositoryAsync<TDataTransferObject> where TDataTransferObject : ResponseEntityBase
	{
		private readonly string url;

		protected RemoteRepositoryAsyncBase(IRestServiceClient restServiceClient, string url) : base(restServiceClient)
		{
			url.ThrowIfNullOrEmpty(nameof(url));

			if (url.EndsWith("/") == false)
			{
				url = $"{url}/";
			}

			this.url = url;
		}

		public async Task<TDataTransferObject> GetByIdAsync(int id)
		{
			try
			{
				var fullUrl = AddJsonSuffix($"{url}{id}");
				var result = await GetAsync<TDataTransferObject>(fullUrl);

				return result;
			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return default(TDataTransferObject);
			}
		}

		public async Task<IEnumerable<TDataTransferObject>> GetAllAsync()
		{
			var result = await GetAllAsync(null);

			return result;
		}

		public async Task<PageResults<TDataTransferObject>> GetPageAsync(int page, int limit)
		{
			try
			{
				var offset = page*limit;
				var request = new ServiceClientRequest();
				request.Parameters.Add(Configuration.Parameters.Limit, limit);
				request.Parameters.Add(Configuration.Parameters.Offset, offset);

				var result = await GetAsync<PageResults<TDataTransferObject>>(url, request);

				return result;
			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return new PageResults<TDataTransferObject>();
			}
		}

		protected async Task<IEnumerable<TDataTransferObject>> GetAllFilteredAsync(List<KeyValuePair<string, object>> filters)
		{
			var arrayOfFilters = filters.ToArray();
			var results = await GetAllFilteredAsync(arrayOfFilters);

			return results;
		}

		protected async Task<IEnumerable<TDataTransferObject>> GetAllFilteredAsync(params KeyValuePair<string, object>[] filters)
		{
			try
			{
				var request = ProduceServiceRequestWithParameters(filters);
				var result = await GetAllAsync(request);

				return result;
			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return new TDataTransferObject[0];
			}
		}

		protected async Task<IEnumerable<TDataTransferObject>> GetAllAsync(IServiceClientRequest request)
		{
			try
			{
				var nextUrl = url;
				List<TDataTransferObject> list = null;
				while (string.IsNullOrEmpty(nextUrl) == false)
				{
					var result = await GetAsync<PageResults<TDataTransferObject>>(url, request);
					nextUrl = result.NextResultsUrl;
					if (list == null)
					{
						var count = result.TotalCount;
						list = new List<TDataTransferObject>(count);
					}
					list.AddRange(result.Results);
				}

				return list;

			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return new TDataTransferObject[0];
			}
		}

		protected async Task<PageResults<TDataTransferObject>> GetFilteredAsync(List<KeyValuePair<string, object>> filters)
		{
			var arrayOfFilters = filters.ToArray();
			var pageResult = await GetFilteredAsync(arrayOfFilters);

			return pageResult;
		}

		protected async Task<PageResults<TDataTransferObject>> GetFilteredAsync(params KeyValuePair<string, object>[] filters)
		{
			try
			{
				var request = ProduceServiceRequestWithParameters(filters);
				var result = await GetAsync<PageResults<TDataTransferObject>>(url, request);

				return result;
			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return new PageResults<TDataTransferObject>();
			}
		}

		private static ServiceClientRequest ProduceServiceRequestWithParameters(IEnumerable<KeyValuePair<string, object>> parameters)
		{
			var request = new ServiceClientRequest();
			foreach (var parameter in parameters)
			{
				request.Parameters.Add(parameter.Key, parameter.Value);
			}

			return request;
		}

		public async Task<TDataTransferObject> GetAsync(IServiceClientRequest request = null)
		{
			try
			{
				var result = await GetAsync<TDataTransferObject>(url, request);

				return result;
			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return default(TDataTransferObject);
			}
		}

		public async Task<TDataTransferObject> PostAsync(IServiceClientRequest request = null)
		{
			try
			{
				var result = await PostAsync<TDataTransferObject>(url, request);

				return result;
			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return default(TDataTransferObject);
			}
		}

		public async Task<byte[]> PostBytesAsync(IServiceClientRequest request = null)
		{
			try
			{
				var result = await PostAsync<byte[]>(url, request);

				return result;
			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return new byte[0];
			}
		}

		public async Task<TDataTransferObject> PutAsync(IServiceClientRequest request = null)
		{
			try
			{
				var result = await PostAsync<TDataTransferObject>(url, request);

				return result;
			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return default(TDataTransferObject);
			}
		}

		public async Task<TDataTransferObject> DeleteAsync(IServiceClientRequest request = null)
		{
			try
			{
				var result = await DeleteAsync<TDataTransferObject>(url, request);

				return result;
			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return default(TDataTransferObject);
			}
		}

		protected static string AddJsonSuffix(string url)
		{
			if (url.EndsWith("/"))
			{
				url = url.Remove(url.Length - 2, 1);
			}

			url = $"{url}{Configuration.Urls.UrlEnding}";

			return url;
		}
	}
}
