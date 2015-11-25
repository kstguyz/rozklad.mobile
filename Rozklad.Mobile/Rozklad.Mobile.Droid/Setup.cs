using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Rozklad.Mobile.Core.DataBase;
using Rozklad.Mobile.Core.Extensions;
using Rozklad.Mobile.Core.PlatformServices;

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
            Mvx.RegisterSingleton<ISqlitePlatformContext>(() => new SqlitePlatformContext());
		    Mvx.RegisterSingleton<IConsoleLogger>(ProduceLogger);
	    }

	    private static IConsoleLogger ProduceLogger()
	    {
			var appContext = Resolve<IMvxAndroidGlobals>().ApplicationContext;
			var appName = appContext.GetString(Resource.String.ApplicationName);
			var logger = new PlatformServices.ConsoleLogger(appName);

			return logger;
		}

		private static T Resolve<T>() where T : class
		{
			return ContainerExtensions.Resolve<T>();
		}
	}
}