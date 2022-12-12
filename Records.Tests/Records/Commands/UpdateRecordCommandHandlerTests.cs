using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Records.Application.Common.Exceptions;
using Records.Application.Records.Commands.UpdateRecord;
using Records.Tests.Common;
using Xunit;

namespace Records.Tests.Records.Commands
{
	public class UpdateRecordCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task UpdateRecordCommandHandler_Success()
		{
			// Arrange
			var handler = new UpdateRecordCommandHandler(Context);
			var updatedTitle = "new title";

			// Act
			await handler.Handle(new UpdateRecordCommand
			{
				Id = RecordsContextFactory.RecordIdForUpdate,
				UserId = RecordsContextFactory.UserBId,
				Title = updatedTitle
			}, CancellationToken.None);

			// Assert
			Assert.NotNull(await Context.Records.SingleOrDefaultAsync(record =>
				record.Id == RecordsContextFactory.RecordIdForUpdate &&
				record.Title == updatedTitle));
		}

		[Fact]
		public async Task UpdateRecordCommandHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new UpdateRecordCommandHandler(Context);

			// Act
			// Assert
			await Assert.ThrowsAsync<NotFoundException>(async () =>
				await handler.Handle(
					new UpdateRecordCommand
					{
						Id = Guid.NewGuid(),
						UserId = RecordsContextFactory.UserAId
					},
					CancellationToken.None));
		}

		[Fact]
		public async Task UpdateRecordCommandHandler_FailOnWrongUserId()
		{
			// Arrange
			var handler = new UpdateRecordCommandHandler(Context);

			// Act
			// Assert
			await Assert.ThrowsAsync<NotFoundException>(async () =>
			{
				await handler.Handle(
					new UpdateRecordCommand
					{
						Id = RecordsContextFactory.RecordIdForUpdate,
						UserId = RecordsContextFactory.UserAId
					},
					CancellationToken.None);
			});
		}
	}
}
