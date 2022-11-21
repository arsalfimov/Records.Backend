using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Records.Application.Interfaces;

namespace Records.Application.Records.Queries.GetRecordList
{
    public class GetRecordListQueryHandler 
        : IRequestHandler<GetRecordListQuery, RecordListVm>
    {
        private readonly IRecordsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRecordListQueryHandler(IRecordsDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<RecordListVm> Handle(GetRecordListQuery request,
            CancellationToken cancellationToken)
        {
            var recordsQuery = await _dbContext.Records
                .Where(record => record.UserId == request.UserId)
                .ProjectTo<RecordLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new RecordListVm { Records = recordsQuery };
        }
    }
}
