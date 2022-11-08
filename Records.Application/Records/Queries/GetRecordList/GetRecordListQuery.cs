using System;
using MediatR;

namespace Records.Application.Records.Queries.GetRecordList
{
    public class GetRecordListQuery : IRequest<RecordListVm>
    {
        public Guid UserId { get; set; }
    }
}
