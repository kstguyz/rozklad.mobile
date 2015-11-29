using System.Collections;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Binding.ExtensionMethods;
using Rozklad.Mobile.Core.Extensions;
using Rozklad.Mobile.Droid.Views.Controls;

namespace Rozklad.Mobile.Droid.Adapters
{
	public class RecycleViewBindableAdapter : RecyclerView.Adapter
	{
		protected class ViewHolder : RecyclerView.ViewHolder
		{
			public ViewHolder(View view) : base(view) { }
		}

		private readonly Context context;
		protected readonly IMvxLayoutInflater LayoutInflater;
		protected readonly IMvxAndroidBindingContext BindingContext;

		private IEnumerable itemsSource;
		private int templateId;

		public RecycleViewBindableAdapter(Context context, IMvxAndroidBindingContext bindingContext)
		{
			context.ThrowIfNull(nameof(context));
			bindingContext.ThrowIfNull(nameof(bindingContext));

			this.context = context;
			LayoutInflater = bindingContext.LayoutInflater;
			BindingContext = bindingContext;
		}

		public override int ItemCount => itemsSource?.Count() ?? 0;

		public IEnumerable ItemsSource
		{
			get { return itemsSource; }
			set { SetItemsSource(value); }
		}

		public int TemplateId
		{
			get { return templateId; }
			set { templateId = value; }
		}

		public override int GetItemViewType(int position)
		{
			return 0;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup viewGroup, int viewType)
		{
			var view = CreateFirstView(templateId);
			var viewHolder = new ViewHolder(view);

			return viewHolder;
		}

		// Replace the contents of a view (invoked by the layout manager)
		public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
		{
			var customViewHolder = (ViewHolder)viewHolder;
			var view = customViewHolder.ItemView;
			view = CreateBindableView(position, templateId, view);
			customViewHolder.ItemView = view;
		}

		protected virtual View CreateBindableView(int position, int templateId, View convertView)
		{
			var dataContext = GetElementAt(position);
			var recycleItemView = convertView as RecycleItemView;
			recycleItemView = CreateBindableView(templateId, recycleItemView, dataContext, LayoutInflater);

			return recycleItemView;
		}

		protected virtual RecycleItemView CreateFirstView(int templateId)
		{
			var view = CreateBindableView(templateId, null, null, LayoutInflater);

			return view;
		}

		protected virtual RecycleItemView CreateBindableView(int templateId, RecycleItemView convertView, object dataContext, IMvxLayoutInflater mvxLayoutInflater)
		{
			if (convertView != null && convertView.TemplateId == templateId)
			{
				convertView.DataContext = dataContext;
			}
			else
			{
				convertView = new RecycleItemView(context, mvxLayoutInflater, dataContext, templateId);
			}

			return convertView;
		}

		protected virtual void SetItemsSource(IEnumerable value)
		{
			itemsSource = value;
			NotifyDataSetChanged();
		}

		protected object GetElementAt(int position)
		{
			var element = itemsSource.ElementAt(position);

			return element;
		}
	}
}
