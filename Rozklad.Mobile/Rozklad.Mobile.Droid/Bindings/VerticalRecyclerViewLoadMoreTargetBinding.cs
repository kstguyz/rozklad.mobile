using Rozklad.Mobile.Droid.Views.Controls;

namespace Rozklad.Mobile.Droid.Bindings
{
	public class VerticalRecyclerViewLoadMoreTargetBinding : BaseCommandTargetBinding<VerticalRecyclerView>
	{
		public VerticalRecyclerViewLoadMoreTargetBinding(VerticalRecyclerView targetObject) : base(targetObject) { }

		protected override void SubscribeToTargetEvents(VerticalRecyclerView target)
		{
			target.LoadMore += OnLoadMore;
		}

		protected override void UnsubscribeFromTargetEvents(VerticalRecyclerView target)
		{
			target.LoadMore -= OnLoadMore;
		}

		private void OnLoadMore(object sender, int e)
		{
			Execute(e);
		}
	}
}