using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using RestSharp.Portable;
using Rozklad.Mobile.Core.Extensions;
using Rozklad.Mobile.Core.WebService.Exceptions;

namespace Rozklad.Mobile.Core.WebService.RestSharp
{
	internal static class Utility
	{
		/// <summary>
		/// Creates IRestSharp native request.
		/// </summary>
		/// <returns>The rest sharp request.</returns>
		/// <param name="apiRequest">API request.</param>
		/// <param name="method">Method.</param>
		internal static RestRequest CreateRestSharpRequest(string uri, IServiceClientRequest apiRequest, HttpMethod method)
		{
			var restRequest = new RestRequest(uri, method);

			if (apiRequest == null)
				return restRequest;

			if (method != HttpMethod.Put && apiRequest.Parameters != null && apiRequest.Parameters.Any())
			{
				foreach (var parameter in apiRequest.Parameters)
				{
					restRequest.AddParameter(parameter.Key, parameter.Value);
				}
			}
			if (apiRequest.Headers != null && apiRequest.Headers.Any())
			{
				foreach (var header in apiRequest.Headers)
				{
					restRequest.AddHeader(header.Key, header.Value);
				}
			}
			if (apiRequest.Cookie != null && apiRequest.Cookie.Any())
			{
				foreach (var header in apiRequest.Cookie)
				{
					restRequest.AddParameter(header.Key, header.Value, ParameterType.Cookie);
				}
			}

			return restRequest;
		}

		internal static void ThrowRequestFailed(string uri, IRestResponse response)
		{
			var responseText = System.Text.Encoding.UTF8.GetString(response.RawBytes, 0, response.RawBytes.Length);

			ConsoleLogger.Trace($"{uri} return status '{response.StatusCode}' and data: {responseText}");
			Exception ex = null;
			switch (response.StatusCode)
			{
				case HttpStatusCode.BadRequest:
					ex = new BadRequestException(responseText);
					break;
				default:
					ex = new Exception(responseText);
					break;
			}

			throw ex;
		}
	}
}

