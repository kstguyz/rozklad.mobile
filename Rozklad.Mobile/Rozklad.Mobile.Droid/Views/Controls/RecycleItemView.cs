using System;
using Android.Content;
using Android.Runtime;
using Cirrious.MvvmCross.Binding.Droid.Views;

namespace Rozklad.Mobile.Droid.Views.Controls
{
	public class RecycleItemView : MvxListItemView
	{
		public RecycleItemView(Context context, IMvxLayoutInflater layoutInflater, object dataContext, int templateId) 
			: base(context, layoutInflater, dataContext, templateId)
		{ }

		public RecycleItemView(IntPtr javaReference, JniHandleOwnership transfer) 
			: base(javaReference, transfer)
		{ }
	}
}
