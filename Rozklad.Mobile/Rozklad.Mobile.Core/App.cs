using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
	    public override void Initialize()
	    {
		    base.Initialize();
			RegisterInIoc();
	    }

        public void RegisterInIoc()
        {
			Mvx.RegisterSingleton<IMvxJsonConverter>(() => new MvxJsonConverter());

			// database
			Mvx.RegisterSingleton<DataBase.IConnectionFactory>(() => new DataBase.SingletonConnectionFactory(Resolve<DataBase.ISqlitePlatformContext>()));

			// local repositories
			Mvx.RegisterSingleton<Repositories.Local.IBuildingRepository>(() => new Repositories.Local.BuildingRepository(Resolve<DataBase.IConnectionFactory>()));
			Mvx.RegisterSingleton<Repositories.Local.IDisciplineRepository>(() => new Repositories.Local.DisciplineRepository(Resolve<DataBase.IConnectionFactory>()));
			Mvx.RegisterSingleton<Repositories.Local.IGroupRepository>(() => new Repositories.Local.GroupRepository(Resolve<DataBase.IConnectionFactory>()));
			Mvx.RegisterSingleton<Repositories.Local.ILessonRepository>(() => new Repositories.Local.LessonRepository(Resolve<DataBase.IConnectionFactory>()));
			Mvx.RegisterSingleton<Repositories.Local.IRoomRepository>(() => new Repositories.Local.RoomRepository(Resolve<DataBase.IConnectionFactory>()));
			Mvx.RegisterSingleton<Repositories.Local.ITeacherRepository>(() => new Repositories.Local.TeacherRepository(Resolve<DataBase.IConnectionFactory>()));

			// web service
			Mvx.RegisterSingleton<WebService.Rest.IRestServiceClient>(() => new WebService.RestSharp.RestSharpClient());

			// remote repositories
			Mvx.RegisterSingleton<Repositories.Remote.IBuildingRepository>(() => new Repositories.Remote.BuildingRepository(Resolve<WebService.Rest.IRestServiceClient>(), Configuration.Urls.BuildingsUrl));
			Mvx.RegisterSingleton<Repositories.Remote.IDisciplineRepository>(() => new Repositories.Remote.DisciplineRepository(Resolve<WebService.Rest.IRestServiceClient>(), Configuration.Urls.DisciplinesUrl));
			Mvx.RegisterSingleton<Repositories.Remote.IGroupRepository>(() => new Repositories.Remote.GroupRepository(Resolve<WebService.Rest.IRestServiceClient>(), Configuration.Urls.GroupsUrl));
			Mvx.RegisterSingleton<Repositories.Remote.ILessonRepository>(() => new Repositories.Remote.LessonRepository(Resolve<WebService.Rest.IRestServiceClient>(), Configuration.Urls.LessonsUrl));
			Mvx.RegisterSingleton<Repositories.Remote.IRoomRepository>(() => new Repositories.Remote.RoomRepository(Resolve<WebService.Rest.IRestServiceClient>(), Configuration.Urls.RoomsUrl));
			Mvx.RegisterSingleton<Repositories.Remote.ITeacherRepository>(() => new Repositories.Remote.TeacherRepository(Resolve<WebService.Rest.IRestServiceClient>(), Configuration.Urls.TeachersUrl));
		}

		private static T Resolve<T>() where T : class
		{
			return ContainerExtensions.Resolve<T>();
		}
	}
}