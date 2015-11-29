using System;
using System.Windows.Input;
using Cirrious.MvvmCross.Binding;

namespace Rozklad.Mobile.Droid.Bindings
{
	public class BaseCommandTargetBinding<TTarget> : BaseTargetBinding<ICommand, TTarget>
	where TTarget : class
	{
		private ICommand command;

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneTime;

		public BaseCommandTargetBinding(TTarget target) : base(target) { }

		protected virtual void DoOnHandlerCalled(object sender, EventArgs e)
		{
			Execute(null);
		}

		protected virtual bool CanExecute(object parameter = null)
		{
			return command != null && command.CanExecute(parameter);
		}

		protected virtual void Execute()
		{
			Execute(null);
		}

		protected virtual void Execute(object parameter)
		{
			command?.Execute(parameter);
		}

		public override void SetValue(object value)
		{
			command = value as ICommand;
		}
	}
}
