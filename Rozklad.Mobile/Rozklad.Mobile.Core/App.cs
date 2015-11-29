using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core
{
    public class App : MvxApplication
    {
	    public override void Initialize()
	    {
			RegisterInIoc();
			RegisterAppStart(Resolve<IMvxAppStart>());
		}

		public void RegisterInIoc()
        {
			Mvx.RegisterSingleton<IMvxJsonConverter>(() => new MvxJsonConverter());
			Mvx.RegisterSingleton<IMvxAppStart>(() => new AppStart());

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

			// business logic
			Mvx.RegisterSingleton<BusinessLogic.IEntityFetcher> (() => new BusinessLogic.EntityFetcher());
			Mvx.RegisterSingleton<BusinessLogic.IDisciplineSearch>(() => new BusinessLogic.DisciplineSearch(Resolve<Repositories.Remote.IDisciplineRepository>(),
																											Resolve<Repositories.Local.IDisciplineRepository>(),
																											Resolve<BusinessLogic.Converters.IDisciplineConverter>(),
                                                                                                            Resolve<BusinessLogic.IEntityFetcher>()));
			Mvx.RegisterSingleton<BusinessLogic.IGroupSearch>(() => new BusinessLogic.GroupSearch(Resolve<Repositories.Remote.IGroupRepository>(),
																								  Resolve<Repositories.Local.IGroupRepository>(),
																								  Resolve<BusinessLogic.Converters.IGroupConverter>(),
																								  Resolve<BusinessLogic.IEntityFetcher>()));
			Mvx.RegisterSingleton<BusinessLogic.ITeacherSearch>(() => new BusinessLogic.TeacherSearch(Resolve<Repositories.Remote.ITeacherRepository>(),
																									  Resolve<Repositories.Local.ITeacherRepository>(),
																									  Resolve<BusinessLogic.Converters.ITeacherConverter>(),
																									  Resolve<BusinessLogic.IEntityFetcher>()));
			Mvx.RegisterSingleton<BusinessLogic.IBuildingSearch>(() => new BusinessLogic.BuildingSearch(Resolve<Repositories.Remote.IBuildingRepository>(),
																										Resolve<Repositories.Local.IBuildingRepository>(),
																										Resolve<BusinessLogic.Converters.IBuildingConverter>(),
																										Resolve<BusinessLogic.IEntityFetcher>()));
			Mvx.RegisterSingleton<BusinessLogic.IRoomSearch>(() => new BusinessLogic.RoomSearch(Resolve<Repositories.Remote.IRoomRepository>(),
																								Resolve<Repositories.Local.IRoomRepository>(),
																								Resolve<BusinessLogic.Converters.IRoomConverter>(),
																								Resolve<BusinessLogic.IEntityFetcher>(),
																								Resolve<BusinessLogic.IBuildingSearch>()));
			Mvx.RegisterSingleton<BusinessLogic.ILessonSearch>(() => new BusinessLogic.LessonSearch(Resolve<Repositories.Remote.ILessonRepository>(),
																									Resolve<Repositories.Local.ILessonRepository>(),
																									Resolve<BusinessLogic.Converters.ILessonConverter>(),
																									Resolve<BusinessLogic.IEntityFetcher>(),
																									Resolve<BusinessLogic.IDisciplineSearch>(),
																									Resolve<BusinessLogic.IGroupSearch>(),
																									Resolve<BusinessLogic.ITeacherSearch>(),
																									Resolve<BusinessLogic.IRoomSearch>()));
			// business logic - converters
			Mvx.RegisterSingleton<BusinessLogic.Converters.IDisciplineConverter> (() => new BusinessLogic.Converters.DisciplineConverter());
			Mvx.RegisterSingleton<BusinessLogic.Converters.IGroupConverter> (() => new BusinessLogic.Converters.GroupConverter());
			Mvx.RegisterSingleton<BusinessLogic.Converters.IBuildingConverter> (() => new BusinessLogic.Converters.BuildingConverter());
			Mvx.RegisterSingleton<BusinessLogic.Converters.IRoomConverter> (() => new BusinessLogic.Converters.RoomConverter());
			Mvx.RegisterSingleton<BusinessLogic.Converters.ITeacherConverter> (() => new BusinessLogic.Converters.TeacherConverter());
			Mvx.RegisterSingleton<BusinessLogic.Converters.ILessonConverter> (() => new BusinessLogic.Converters.LessonConverter());

			// viewmodels
			Mvx.RegisterSingleton<ViewModels.IViewModelFactory>(() => new ViewModels.ViewModelFactory(Resolve<IMvxViewModelLoader>()));
		}

		private static T Resolve<T>() where T : class
		{
			return ContainerExtensions.Resolve<T>();
		}
	}
}
