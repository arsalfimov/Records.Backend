using System;
using MediatR;

namespace Records.Application.Records.Commands.UpdateRecord
{
    public class UpdateRecordCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
