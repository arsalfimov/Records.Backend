using System;
using MediatR;

namespace Records.Application.Records.Commands.DeleteCommand
{
    public class DeleteRecordCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
