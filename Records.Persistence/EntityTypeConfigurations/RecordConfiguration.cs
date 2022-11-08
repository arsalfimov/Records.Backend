using Records.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Records.Persistence.EntityTypeConfigurations
{
    public class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.HasKey(record => record.Id);
            builder.HasIndex(record => record.Id).IsUnique();
            builder.Property(record => record.Title).HasMaxLength(250);
        }
    }
}
