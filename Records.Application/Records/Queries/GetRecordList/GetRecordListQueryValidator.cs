using System;
using FluentValidation;

namespace Records.Application.Records.Queries.GetRecordList
{
    public class GetRecordListQueryValidator : AbstractValidator<GetRecordListQuery>
    {
        public GetRecordListQueryValidator() 
        {
            RuleFor(record => record.UserId).NotEqual(Guid.Empty);
        }
    }
}
