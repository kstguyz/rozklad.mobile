using System.Threading.Tasks;
using Rozklad.Mobile.Core.WebService.DataContracts.Response;

namespace Rozklad.Mobile.Core.Repositories.Remote
{
	public interface ITeacherRepository
	{
		Task<PageResults<Teacher>> FilterAsync(string lastName = "", string firstName = "", string middleName = "", string degree = "");
	}
}