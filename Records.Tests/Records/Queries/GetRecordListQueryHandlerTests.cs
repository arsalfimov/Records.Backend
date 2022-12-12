using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Records.Application.Records.Queries.GetRecordList;
using Records.Persistence;
using Records.Tests.Common;
using Shouldly;
using Xunit;

namespace Records.Tests.Records.Queries
{
	public class GetRecordListQueryHandlerTests
	{
		[Collection("QueryCollection")]
		public class GetNoteListQueryHandlerTests
		{
			private readonly RecordsDbContext Context;
			private readonly IMapper Mapper;

			public GetNoteListQueryHandlerTests(QueryTestFixture fixture)
			{
				Context = fixture.Context;
				Mapper = fixture.Mapper;
			}

			[Fact]
			public async Task GetNoteListQueryHandler_Success()
			{
				// Arrange
				var handler = new GetRecordListQueryHandler(Context, Mapper);

				// Act
				var result = await handler.Handle(
					new GetRecordListQuery
					{
						UserId = RecordsContextFactory.UserBId
					},
					CancellationToken.None);

				// Assert
				result.ShouldBeOfType<RecordListVm>();
				result.Records.Count.ShouldBe(2);
			}
		}
	}
}
