using System;
using MediatR;

namespace Records.Application.Records.Queries.GetRecordDetails
{
    public class GetRecordDetailsQuery : IRequest<RecordDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
