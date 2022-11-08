using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Records.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Records.Application.Common.Exceptions;
using Records.Domain;

namespace Records.Application.Records.Queries.GetRecordDetails
{
    public class GetRecordDetailsQueryHandler
    : IRequestHandler<GetRecordDetailsQuery, RecordDetailsVm>
    {
        private readonly IRecordsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRecordDetailsQueryHandler(IRecordsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<RecordDetailsVm> Handle(GetRecordDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Records
                .FirstOrDefaultAsync(record =>
                record.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Record), request.Id);
            }

            return _mapper.Map<RecordDetailsVm>(entity);
        }
    }
}
