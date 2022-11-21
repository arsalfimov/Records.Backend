using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Records.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            return services;
        }
    }
}