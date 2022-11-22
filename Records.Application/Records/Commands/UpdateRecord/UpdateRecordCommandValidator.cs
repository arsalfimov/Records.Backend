using System;
using FluentValidation;

namespace Records.Application.Records.Commands.UpdateRecord
{
    public class UpdateRecordCommandValidator : AbstractValidator<UpdateRecordCommand>
    {
        public UpdateRecordCommandValidator()
        {
            RuleFor(updateRecordCommand =>
                updateRecordCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateRecordCommand =>
                updateRecordCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateRecordCommand =>
                updateRecordCommand.Title).NotEmpty().MaximumLength(250);
        }
    }
}