using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Records.Application.Interfaces;
using Records.Domain;

namespace Records.Application.Records.Commands.CreateRecord
{
    public class CreateRecordCommandHandler
    : IRequestHandler<CreateRecordCommand, Guid>
    {
        private readonly IRecordsDbContext _dbContext;

        public CreateRecordCommandHandler(IRecordsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateRecordCommand request,
            CancellationToken cancellationToken)
        {
            var record = new Record
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Records.AddAsync(record, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return record.Id;
        }
    }
}