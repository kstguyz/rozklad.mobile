using Cirrious.MvvmCross.ViewModels;
using Rozklad.Mobile.Core.ViewModels;

namespace Rozklad.Mobile.Core
{
	public class AppStart : MvxNavigatingObject, IMvxAppStart
	{
		public void Start(object hint = null)
		{
			ShowViewModel<GroupTimeTableViewModel>();
		}
	}
}
