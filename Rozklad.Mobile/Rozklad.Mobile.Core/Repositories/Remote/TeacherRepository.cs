using System.Collections.Generic;
using System.Threading.Tasks;
using Rozklad.Mobile.Core.Configuration;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;
using Rozklad.Mobile.Core.WebService.Rest;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public class TeacherRepository : RemoteRepositoryAsyncBase<Teacher>, ITeacherRepository
	{
		public TeacherRepository(IRestServiceClient restServiceClient, string url) 
			: base(restServiceClient, url)
		{ }

		public async Task<PageResults<Teacher>> FilterAsync(string lastName = "",
		                                                    string firstName = "",
		                                                    string middleName = "",
		                                                    string degree = "")
		{
			var parameters = ProduceParameters(lastName, firstName, middleName, degree);
			var result = await GetFilteredAsync(parameters);

			return result;
		}

		public async Task<IEnumerable<Teacher>> FilterAllAsync(string lastName = "",
		                                                       string firstName = "",
		                                                       string middleName = "",
		                                                       string degree = "")
		{
			var parameters = ProduceParameters(lastName, firstName, middleName, degree);
			var result = await GetAllFilteredAsync(parameters);

			return result;
		}

		private static List<KeyValuePair<string, object>> ProduceParameters(string lastName = "",
		                                                                    string firstName = "",
		                                                                    string middleName = "",
		                                                                    string degree = "")
		{
			var parameters = new List<KeyValuePair<string, object>>();
			if (string.IsNullOrEmpty(lastName) == false)
			{
				parameters.Add(GetLastNameParameter(lastName));
			}
			if (string.IsNullOrEmpty(firstName) == false)
			{
				parameters.Add(GetFirstNameParameter(firstName));
			}
			if (string.IsNullOrEmpty(middleName) == false)
			{
				parameters.Add(GetMiddleNameParameter(middleName));
			}
			if (string.IsNullOrEmpty(degree) == false)
			{
				parameters.Add(GetDegreeParameter(degree));
			}

			return parameters;
		}

		private static KeyValuePair<string, object> GetFirstNameParameter(string lastName)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Teacher.FirstName, lastName);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetLastNameParameter(string middleName)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Teacher.LastName, middleName);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetMiddleNameParameter(string degree)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Teacher.MiddleName, degree);

			return keyValuePair;
		}

		private static KeyValuePair<string, object> GetDegreeParameter(string degree)
		{
			var keyValuePair = new KeyValuePair<string, object>(Parameters.Teacher.Degree, degree);

			return keyValuePair;
		}
	}
}
