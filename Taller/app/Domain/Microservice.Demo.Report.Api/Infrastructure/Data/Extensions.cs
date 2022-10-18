using Microservice.Demo.Report.Api.Infrastructure.Data.Context;
using Microservice.Demo.Report.Api.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Demo.Report.Api.Infrastructure.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services,IConfiguration configuration)
        {
            var policyConnection = configuration.GetConnectionString("ReportConnection");
            services.AddDbContext<ReportDbContext>(options =>
            {
                options.UseSqlServer(policyConnection);
            });

            services.AddScoped<IPolicyRepository, PolicyRepository>();

            return services;
        }
    }
}
