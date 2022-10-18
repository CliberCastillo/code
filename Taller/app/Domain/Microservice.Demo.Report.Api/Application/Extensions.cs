using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Demo.Report.Api.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ReportApplicationService>();

            return services;
        }
    }
}
