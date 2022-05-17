using Microsoft.EntityFrameworkCore;
using Payslip.Infra.Data.Contexts;

namespace Payslip.Api.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var payslipDbContext = scope.ServiceProvider.GetRequiredService<PayslipDbContext>();
                payslipDbContext.Database.Migrate();
            }
        }
    }
}
