using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Records.Application.Common.Exceptions;
using Records.Application.Records.Commands.CreateRecord;
using Records.Application.Records.Commands.DeleteCommand;
using Records.Tests.Common;
using Xunit;

namespace Records.Tests.Records.Commands
{
	public class DeleteRecordCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task DeleteRecordCommandHandler_Success()
		{
			// Arrange
			var handler = new DeleteRecordCommandHandler(Context);

			// Act
			await handler.Handle(new DeleteRecordCommand
			{
				Id = RecordsContextFactory.RecordIdForDelete,
				UserId = RecordsContextFactory.UserAId
			}, CancellationToken.None);

			// Assert
			Assert.Null(Context.Records.SingleOrDefault(record =>
				record.Id == RecordsContextFactory.RecordIdForDelete));
		}

		[Fact]
		public async Task DeleteRecordCommandHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new DeleteRecordCommandHandler(Context);

			// Act
			// Assert
			await Assert.ThrowsAsync<NotFoundException>(async () =>
				await handler.Handle(
					new DeleteRecordCommand
					{
						Id = Guid.NewGuid(),
						UserId = RecordsContextFactory.UserAId
					},
					CancellationToken.None));
		}

		[Fact]
		public async Task DeleteRecordCommandHandler_FailOnWrongUserId()
		{
			// Arrange
			var deleteHandler = new DeleteRecordCommandHandler(Context);
			var createHandler = new CreateRecordCommandHandler(Context);
			var recordId = await createHandler.Handle(
				new CreateRecordCommand
				{
					Title = "RecordTitle",
					UserId = RecordsContextFactory.UserAId
				}, CancellationToken.None);

			// Act
			// Assert
			await Assert.ThrowsAsync<NotFoundException>(async () =>
				await deleteHandler.Handle(
					new DeleteRecordCommand
					{
						Id = recordId,
						UserId = RecordsContextFactory.UserBId
					}, CancellationToken.None));
		}
	}
}
