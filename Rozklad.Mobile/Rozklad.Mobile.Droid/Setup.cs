using Android.Content;
using Android.Views;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid;
using Cirrious.CrossCore.Droid.Platform;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Rozklad.Mobile.Core.Extensions;
using Rozklad.Mobile.Droid.Bindings;
using Rozklad.Mobile.Droid.Views.Controls;

namespace Rozklad.Mobile.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) 
			: base(applicationContext)
        { }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

	    protected override void InitializeFirstChance()
	    {
		    RgisterInIoc();
            base.InitializeFirstChance();
	    }

	    private static void RgisterInIoc()
	    {
			// database
            Mvx.RegisterSingleton<Core.DataBase.ISqlitePlatformContext>(() => new DataBase.SqlitePlatformContext());

			// services
			Mvx.RegisterSingleton<Services.IAndroidGlobals>(() => new Services.AndroidGlobals(Resolve<IMvxAndroidCurrentTopActivity>()));

			// platform specific
		    Mvx.RegisterSingleton<Core.PlatformServices.IConsoleLogger>(ProduceLogger);
            Mvx.RegisterSingleton<Core.PlatformServices.ISpinner>(() => new PlatformServices.Spinner(Resolve<Services.IAndroidGlobals>()));
            Mvx.RegisterSingleton<Core.PlatformServices.IDeviceInformation>(() => new PlatformServices.DeviceInformation.DeviceInformation(Resolve<IMvxAndroidCurrentTopActivity>()));
		}

		private static Core.PlatformServices.IConsoleLogger ProduceLogger()
	    {
			var appContext = Resolve<IMvxAndroidGlobals>().ApplicationContext;
			var appName = appContext.GetString(Resource.String.ApplicationName);
			var logger = new PlatformServices.ConsoleLogger(appName);

			return logger;
		}

		protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			base.FillTargetFactories(registry);

			registry.RegisterCustomBindingFactory<VerticalRecyclerView>("RecyclerSource", view => new VerticalRecyclerViewRecyclerSourceTargetBinding(view));
			registry.RegisterCustomBindingFactory<VerticalRecyclerView>("LoadMore", view => new VerticalRecyclerViewLoadMoreTargetBinding(view));
		}

		private static T Resolve<T>() where T : class
		{
			return ContainerExtensions.Resolve<T>();
		}
	}
}
