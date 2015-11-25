using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
			Mvx.RegisterSingleton<IMvxJsonConverter>(() => new MvxJsonConverter());

			// local repositories
			Mvx.RegisterSingleton<Repositories.Local.IBuildingRepository>(() => new Repositories.Local.BuildingRepository(Resolve<IConnectionFactory>()));
			Mvx.RegisterSingleton<Repositories.Local.IDisciplineRepository>(() => new Repositories.Local.DisciplineRepository(Resolve<IConnectionFactory>()));
			Mvx.RegisterSingleton<Repositories.Local.IGroupRepository>(() => new Repositories.Local.GroupRepository(Resolve<IConnectionFactory>()));
			Mvx.RegisterSingleton<Repositories.Local.ILessonRepository>(() => new Repositories.Local.LessonRepository(Resolve<IConnectionFactory>()));
			Mvx.RegisterSingleton<Repositories.Local.IRoomRepository>(() => new Repositories.Local.RoomRepository(Resolve<IConnectionFactory>()));
			Mvx.RegisterSingleton<Repositories.Local.ITeacherRepository>(() => new Repositories.Local.TeacherRepository(Resolve<IConnectionFactory>()));

			// web service
			Mvx.RegisterSingleton<WebService.Rest.IRestServiceClient>(() => new WebService.RestSharp.RestSharpClient());

			// remote repositories
		}

		private static T Resolve<T>() where T : class
		{
			return ContainerExtensions.Resolve<T>();
		}
	}
}