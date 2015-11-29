using System;
using System.Collections;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Rozklad.Mobile.Droid.Adapters;
using Rozklad.Mobile.Droid.Listeners;

namespace Rozklad.Mobile.Droid.Views.Controls
{
	public class VerticalRecyclerView : RecyclerView
	{
		protected const int DefaultId = 0;

		public event EventHandler<int> LoadMore;

		private int templateId;
		private IEnumerable itemsSource = new object[0];

		protected VerticalRecyclerView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

		public VerticalRecyclerView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
		{
			Init(context, attrs);
		}

		public VerticalRecyclerView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			Init(context, attrs);
		}

		public VerticalRecyclerView(Context context) : base(context)
		{
			Init(context, null);
		}

		public new RecycleViewBindableAdapter Adapter
		{
			get
			{
				var adapter = GetAdapter();

				return (RecycleViewBindableAdapter)adapter;
			}
			set
			{
				value.TemplateId = templateId;
				value.ItemsSource = itemsSource;
				SetAdapter(value);
			}
		}

		public IEnumerable ItemsSource
		{
			get
			{

				var adapter = Adapter;

				return adapter == null ? itemsSource : Adapter.ItemsSource;
			}
			set
			{
				itemsSource = value;
				var adapter = Adapter;
				if (adapter == null)
					return;

				adapter.ItemsSource = value;
			}
		}

		public int TemplateId
		{
			get
			{
				var adapter = Adapter;

				return adapter == null ? TemplateId : Adapter.TemplateId;
			}
			set
			{
				templateId = value;
				var adapter = Adapter;
				if (adapter == null)
					return;

				adapter.TemplateId = value;
			}
		}

		protected void Init(Context context, IAttributeSet attrs)
		{
			templateId = attrs.GetAttributeResourceValue("http://schemas.android.com/apk/res-auto", "itemTemplate", DefaultId);
			var dividerId = attrs.GetAttributeResourceValue("http://schemas.android.com/apk/res-auto", "listDivider", DefaultId);

			var layoutManager = LayoutManagerFactory(context);
			SetLayoutManager(layoutManager);

			var linearLayoutManager = layoutManager as LinearLayoutManager;
			if (linearLayoutManager != null)
			{
				var scrollListener = new EndlessRecyclerOnScrollListener(linearLayoutManager, OnLoadMore);
				AddOnScrollListener(scrollListener);
			}

			if (dividerId == DefaultId)
				return;

			var drawable = context.Resources.GetDrawable(dividerId);
			var itemDecorator = new DividerItemDecoration(drawable, DividerItemDecoration.Orientation.Vertical);
			AddItemDecoration(itemDecorator);
		}

		protected virtual LayoutManager LayoutManagerFactory(Context context)
		{
			var layoutManager = new LinearLayoutManager(context);

			return layoutManager;
		}

		protected void OnLoadMore(int currentPage)
		{
			var loadMore = LoadMore;
			if (loadMore == null)
				return;

			loadMore(this, currentPage);
		}
	}
}
