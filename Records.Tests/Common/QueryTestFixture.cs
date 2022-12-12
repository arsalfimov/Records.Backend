using AutoMapper;
using System;
using Records.Application.Interfaces;
using Records.Application.Common.Mappings;
using Records.Persistence;
using Xunit;

namespace Records.Tests.Common
{
	public class QueryTestFixture : IDisposable
	{
		public RecordsDbContext Context;
		public IMapper Mapper;

		public QueryTestFixture()
		{
			Context = RecordsContextFactory.Create();
			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AssemblyMappingProfile(
					typeof(IRecordsDbContext).Assembly));
			});
			Mapper = configurationProvider.CreateMapper();
		}

		public void Dispose()
		{
			RecordsContextFactory.Destroy(Context);
		}
	}

	[CollectionDefinition("QueryCollection")]
	public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}