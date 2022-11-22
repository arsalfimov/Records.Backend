using System;
using FluentValidation;

namespace Records.Application.Records.Commands.DeleteCommand
{
    public class DeleteRecordCommandValidator : AbstractValidator<DeleteRecordCommand>
    {
        public DeleteRecordCommandValidator() 
        {
            RuleFor(deleteRecordCommand =>
                deleteRecordCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteRecordCommand =>
                deleteRecordCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
