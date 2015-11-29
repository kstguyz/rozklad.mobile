using Cirrious.MvvmCross.ViewModels;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core.ViewModels
{
	public class ViewModelFactory : IViewModelFactory
	{
		private readonly IMvxViewModelLoader mvxViewModelLoader;

		public ViewModelFactory(IMvxViewModelLoader mvxViewModelLoader)
		{
			mvxViewModelLoader.ThrowIfNull(nameof(mvxViewModelLoader));

			this.mvxViewModelLoader = mvxViewModelLoader;
		}

		public TViewModel Produce<TViewModel>()
			where TViewModel : ViewModelBase
		{
			var type = typeof (TViewModel);
			var request = new MvxViewModelRequest(type, null, null, MvxRequestedBy.UserAction);
			var viewModel = (TViewModel)mvxViewModelLoader.LoadViewModel(request, null);

			return viewModel;
		}
    }
}
