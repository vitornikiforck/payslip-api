using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

namespace Payslip.Api.Extensions
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection AddHealthCheckSMiddleware<T>(this IServiceCollection service) where T : DbContext
        {
            service.AddHealthChecks()
                .AddDbContextCheck<T>();

            return service;
        }

        public static IApplicationBuilder UseHealthChecksMiddleware(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                AllowCachingResponses = false
            });

            return app;
        }
    }
}