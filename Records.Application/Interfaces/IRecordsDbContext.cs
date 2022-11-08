using System.Threading;
using System.Threading.Tasks;
using Records.Domain;
using Microsoft.EntityFrameworkCore;

namespace Records.Application.Interfaces
{
    public interface IRecordsDbContext
    {
        DbSet<Record> Records { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
