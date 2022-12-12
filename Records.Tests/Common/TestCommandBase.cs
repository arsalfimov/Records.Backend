using System;
using Records.Persistence;

namespace Records.Tests.Common
{
	public abstract class TestCommandBase : IDisposable
	{
		protected readonly RecordsDbContext Context;

		public TestCommandBase()
		{
			Context = RecordsContextFactory.Create();
		}

		public void Dispose()
		{
			RecordsContextFactory.Destroy(Context);
		}
	}
}
