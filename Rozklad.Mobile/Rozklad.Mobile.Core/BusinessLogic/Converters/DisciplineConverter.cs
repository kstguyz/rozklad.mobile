
namespace Rozklad.Mobile.Core.BusinessLogic.Converters
{
	public class DisciplineConverter 
		: EntityConverterBase<Entities.Discipline, WebService.DataContracts.Response.Discipline>, IDisciplineConverter
	{
		public override Entities.Discipline Convert(WebService.DataContracts.Response.Discipline webEntity)
		{
			var entity = Entities.Discipline.Convert(webEntity);

			return entity;
		}
	}
}
