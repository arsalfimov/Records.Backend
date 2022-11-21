using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Records.Application.Interfaces;

namespace Records.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<RecordsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IRecordsDbContext>(provider =>
                provider.GetService<RecordsDbContext>());
            return services;
        }
    }
}
