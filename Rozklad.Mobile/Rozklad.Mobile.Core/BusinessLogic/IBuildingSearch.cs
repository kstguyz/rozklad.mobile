using System.Threading.Tasks;

namespace Rozklad.Mobile.Core.BusinessLogic
{
	public interface IBuildingSearch
	{
		Task<Entities.Building> GetByIdAsync(int id);
	}
}
