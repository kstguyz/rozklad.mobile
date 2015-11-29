namespace Rozklad.Mobile.Core.ViewModels
{
	public interface IViewModelFactory
	{
		TViewModel Produce<TViewModel>() where TViewModel : ViewModelBase;
	}
}