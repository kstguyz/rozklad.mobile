using System.Threading.Tasks;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public interface IDisciplineSearch
	{
		Task<Entities.Discipline> GetByIdAsync(int id);
	}
}
