using Microsoft.EntityFrameworkCore;
using Records.Application.Interfaces;
using Records.Domain;
using Records.Persistence.EntityTypeConfigurations;

namespace Records.Persistence
{
    public class RecordsDbContext : DbContext, IRecordsDbContext
    {
        public DbSet<Record> Records { get; set; }

        public RecordsDbContext(DbContextOptions<RecordsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RecordConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
