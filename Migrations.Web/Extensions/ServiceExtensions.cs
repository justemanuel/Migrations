using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Migrations.Web.Contracts;
using Migrations.Web.Repositories;

namespace Migrations.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategory, CategoryRepo>();
        }
    }
}
