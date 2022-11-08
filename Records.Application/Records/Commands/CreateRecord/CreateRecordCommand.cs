using System;
using MediatR;

namespace Records.Application.Records.Commands.CreateRecord
{
    public class CreateRecordCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
