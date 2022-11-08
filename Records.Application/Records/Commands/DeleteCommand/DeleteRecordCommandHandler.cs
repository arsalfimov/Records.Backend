using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Records.Application.Interfaces;
using Records.Application.Common.Exceptions;
using Records.Domain;

namespace Records.Application.Records.Commands.DeleteCommand
{
    public class DeleteRecordCommandHandler 
        : IRequestHandler<DeleteRecordCommand>
    {
        private readonly IRecordsDbContext _dbContext;

        public DeleteRecordCommandHandler(IRecordsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteRecordCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Records
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Record), request.Id);
            }

            _dbContext.Records.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
