using System;
using FluentValidation;

namespace Records.Application.Records.Queries.GetRecordDetails
{
    public class GetRecordDetailsQueryValidator : AbstractValidator<GetRecordDetailsQuery>
    {
        public GetRecordDetailsQueryValidator() 
        {
            RuleFor(record =>
                record.Id).NotEqual(Guid.Empty);
            RuleFor(record =>
                record.UserId).NotEqual(Guid.Empty);
        }
    }
}
