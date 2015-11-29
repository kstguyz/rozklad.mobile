using System;
using Android.Support.V7.Widget;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Droid.Listeners
{
	public class EndlessRecyclerOnScrollListener : RecyclerView.OnScrollListener
	{
		private readonly LinearLayoutManager linearLayoutManager;
		private readonly Action<int> onLoadMore;

		private const int VisibleThreshold = 3; // The minimum amount of items to have below your current scroll position before loading more.

		private int previousTotal = 0; // The total number of items in the dataset after the last load
		private bool loading = true; // True if we are still waiting for the last set of data to load.
		private int firstVisibleItem;
		private int visibleItemCount;
		private int totalItemCount;
		private int currentPage = 1;

		public EndlessRecyclerOnScrollListener(LinearLayoutManager linearLayoutManager, Action<int> onLoadMore)
		{
			linearLayoutManager.ThrowIfNull(nameof(linearLayoutManager));
			onLoadMore.ThrowIfNull(nameof(onLoadMore));

			this.linearLayoutManager = linearLayoutManager;
			this.onLoadMore = onLoadMore;
		}

		public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
		{
			visibleItemCount = recyclerView.ChildCount;
			totalItemCount = linearLayoutManager.ItemCount;
			firstVisibleItem = linearLayoutManager.FindFirstVisibleItemPosition();

			if (loading)
			{
				if (totalItemCount > previousTotal)
				{
					loading = false;
					previousTotal = totalItemCount;
				}
			}

			if (totalItemCount == 0)
				return;

			if (loading || (totalItemCount - visibleItemCount) > (firstVisibleItem + VisibleThreshold))
			{
				// End has been reached
				return;
			}

			// Do something
			currentPage++;

			onLoadMore(currentPage);

			loading = true;
		}
	}
}
