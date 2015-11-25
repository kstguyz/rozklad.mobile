using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Entities;

namespace Rozklad.Mobile.Core.Repositories.Local
{
	public class RoomRepository : LocalRepositoryAsyncBase<Room>, IRoomRepository
	{
		public RoomRepository(IConnectionFactory factory) : base(factory)
		{ }
	}
}