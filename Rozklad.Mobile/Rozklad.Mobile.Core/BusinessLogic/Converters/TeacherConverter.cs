namespace Rozklad.Mobile.Core.BusinessLogic.Converters
{
	public class TeacherConverter
		: EntityConverterBase<Entities.Teacher, WebService.DataContracts.Response.Teacher>, ITeacherConverter
	{
		public override Entities.Teacher Convert(WebService.DataContracts.Response.Teacher webEntity)
		{
			var entity = Entities.Teacher.Convert(webEntity);

			return entity;
		}
	}
}
