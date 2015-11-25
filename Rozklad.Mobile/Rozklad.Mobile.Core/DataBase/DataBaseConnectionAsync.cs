using System;
using Rozklad.Mobile.Core.Extensions;

namespace Rozklad.Mobile.Core.DataBase
{
	public abstract class DataBaseConnectionAsync : IDisposable
	{
		private readonly IConnectionFactory factory;

		protected IConnectionAsync DbConnection => factory.ProduceConnection();

		protected DataBaseConnectionAsync(IConnectionFactory factory)
		{
			factory.ThrowIfNull(nameof(factory));

			this.factory = factory;
		}

		public virtual void Dispose() { }
	}
}
