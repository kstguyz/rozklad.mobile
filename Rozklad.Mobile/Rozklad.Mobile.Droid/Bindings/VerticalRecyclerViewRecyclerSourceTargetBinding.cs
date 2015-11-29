using System;
using System.Collections;
using Rozklad.Mobile.Droid.Views.Controls;

namespace Rozklad.Mobile.Droid.Bindings
{
	public class VerticalRecyclerViewRecyclerSourceTargetBinding : BaseTargetBinding<IEnumerable, VerticalRecyclerView>
	{
		public VerticalRecyclerViewRecyclerSourceTargetBinding(VerticalRecyclerView targetObject) : base(targetObject) { }

		protected override void DoSetValueImpl(VerticalRecyclerView target, IEnumerable value)
		{
			target.ItemsSource = value;
		}
	}
}
