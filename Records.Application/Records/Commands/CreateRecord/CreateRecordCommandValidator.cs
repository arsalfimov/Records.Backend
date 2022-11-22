using System;
using FluentValidation;

namespace Records.Application.Records.Commands.CreateRecord
{
    public class CreateRecordCommandValidator : AbstractValidator<CreateRecordCommand>
    {
        public CreateRecordCommandValidator()
        {
            RuleFor(createRecordCommand =>
                createRecordCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createRecordCommand =>
                createRecordCommand.UserId).NotEqual(Guid.Empty);

        }
    }
}
