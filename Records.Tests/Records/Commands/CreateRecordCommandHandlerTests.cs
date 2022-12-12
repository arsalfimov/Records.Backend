using System;
using Records.Application.Records.Commands.CreateRecord;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Records.Tests.Common;
using Xunit;

namespace Records.Tests.Records.Commands
{
	public class CreateRecordCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task CreateRecordCommandHandler_Success()
		{
			// Arrange
			var handler = new CreateRecordCommandHandler(Context);
			var recordName = "record name";
			var recordDetails = "record details";

			// Act
			var recordId = await handler.Handle(
				new CreateRecordCommand
				{
					Title = recordName,
					Details = recordDetails,
					UserId = RecordsContextFactory.UserAId
				},
				CancellationToken.None);

			// Assert
			Assert.NotNull(
				await Context.Records.SingleOrDefaultAsync(record =>
					record.Id == recordId && record.Title == recordName &&
					record.Details == recordDetails));
		}
	}
}
