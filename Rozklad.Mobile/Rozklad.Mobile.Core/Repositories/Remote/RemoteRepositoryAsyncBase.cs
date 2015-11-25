using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Configuration;
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

		public async Task<PageResults<TDataTransferObject>> GetPageAsync(int page, int limit)
		{
			try
			{
				var offset = page*limit;
				var request = new ServiceClientRequest();
				request.Parameters.Add(Parameters.Limit, limit);
				request.Parameters.Add(Parameters.Offset, offset);

				var result = await GetAsync<PageResults<TDataTransferObject>>(url, request);

				return result;
			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return new PageResults<TDataTransferObject>();
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
				var request = new ServiceClientRequest();
				foreach (var filter in filters)
				{
					request.Parameters.Add(filter.Key, filter.Value);
				}

				var result = await GetAsync<PageResults<TDataTransferObject>>(url, request);

				return result;
			}
			catch (WebServiceException e)
			{
				e.LogToConsole();

				return new PageResults<TDataTransferObject>();
			}
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
