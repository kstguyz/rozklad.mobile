using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.LocalRepositories
{
	public class RoomRepository : LocalRepositoryAsyncBase<Room>
	{
		public RoomRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}