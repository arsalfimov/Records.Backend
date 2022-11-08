using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Records.Application.Interfaces;
using Records.Application.Common.Exceptions;
using Records.Domain;

namespace Records.Application.Records.Commands.UpdateRecord
{
    public class UpdateRecordCommandHandler
        : IRequestHandler<UpdateRecordCommand>
    {
        private readonly IRecordsDbContext _dbContext;

        public UpdateRecordCommandHandler(IRecordsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateRecordCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Records.FirstOrDefaultAsync(record =>
                    record.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Record), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
