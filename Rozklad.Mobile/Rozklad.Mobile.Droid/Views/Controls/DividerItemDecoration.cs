using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Droid.Views.Controls
{
	public class DividerItemDecoration : RecyclerView.ItemDecoration
	{
		public enum Orientation
		{
			Horizontal = LinearLayoutManager.Horizontal,
			Vertical = LinearLayoutManager.Vertical,
		}

		public static int HorizontalList = LinearLayoutManager.Horizontal;
		public static int VerticalList = LinearLayoutManager.Vertical;

		private readonly Drawable divider;

		private int orientation;

		public DividerItemDecoration(Drawable drawable, Orientation orientation)
		{
			drawable.ThrowIfNull(nameof(drawable));

			divider = drawable;
			SetOrientation(orientation);
		}

		public void SetOrientation(Orientation orientation)
		{
			var i = (int)orientation;
			if (i != HorizontalList && i != VerticalList)
				throw new ArgumentOutOfRangeException(nameof(orientation), "invalid orientation");

			this.orientation = i;
		}

		public override void OnDraw(Canvas c, RecyclerView parent)
		{
			if (orientation == VerticalList)
			{
				DrawVertical(c, parent);
			}
			else
			{
				DrawHorizontal(c, parent);
			}
		}

		private void DrawVertical(Canvas c, RecyclerView parent)
		{
			var left = parent.PaddingLeft;
			var right = parent.Width - parent.PaddingRight;

			var childCount = parent.ChildCount;
			for (var i = 0; i < childCount; i++)
			{
				var child = parent.GetChildAt(i);
				var top = child.Bottom;
				var bottom = top + divider.IntrinsicHeight;
				divider.Bounds = new Rect(left, top, right, bottom);
				divider.Draw(c);
			}
		}

		private void DrawHorizontal(Canvas c, RecyclerView parent)
		{
			var top = parent.PaddingTop;
			var bottom = parent.Height - parent.PaddingBottom;

			var childCount = parent.ChildCount;
			for (var i = 0; i < childCount; i++)
			{
				var child = parent.GetChildAt(i);
				var left = child.Right;
				var right = left + divider.IntrinsicHeight;
				divider.Bounds = new Rect(left, top, right, bottom);
				divider.Draw(c);
			}
		}


		public override void GetItemOffsets(Rect outRect, int itemPosition, RecyclerView parent)
		{
			if (orientation == VerticalList)
			{
				outRect.Set(0, 0, 0, divider.IntrinsicHeight);
			}
			else
			{
				outRect.Set(0, 0, divider.IntrinsicWidth, 0);
			}
		}
	}
}
