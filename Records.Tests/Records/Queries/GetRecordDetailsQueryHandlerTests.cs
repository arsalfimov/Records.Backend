using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Records.Application.Records.Queries.GetRecordDetails;
using Records.Persistence;
using Records.Tests.Common;
using Shouldly;
using Xunit;

namespace Records.Tests.Records.Queries
{
	public class GetRecordDetailsQueryHandlerTests
	{

		[Collection("QueryCollection")]
		public class GetNoteDetailsQueryHandlerTests
		{
			private readonly RecordsDbContext Context;
			private readonly IMapper Mapper;

			public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
			{
				Context = fixture.Context;
				Mapper = fixture.Mapper;
			}

			[Fact]
			public async Task GetNoteDetailsQueryHandler_Success()
			{
				// Arrange
				var handler = new GetRecordDetailsQueryHandler(Context, Mapper);

				// Act
				var result = await handler.Handle(
					new GetRecordDetailsQuery
					{
						UserId = RecordsContextFactory.UserBId,
						Id = Guid.Parse("96339AD8-13B1-421F-AE18-D699A331EFF5")
					},
					CancellationToken.None);

				// Assert
				result.ShouldBeOfType<RecordDetailsVm>();
				result.Title.ShouldBe("Title2");
				result.CreationDate.ShouldBe(DateTime.Today);
			}
		}
	}
}
