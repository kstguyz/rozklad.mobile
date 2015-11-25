namespace Rozklad.Mobile.Core.DataBase
{
	public interface IConnectionFactory
	{
		IConnectionAsync ProduceConnection();
	}
}
