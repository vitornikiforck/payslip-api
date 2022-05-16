using Microsoft.EntityFrameworkCore;
using Payslip.Api.Settings;
using Payslip.Domain.Features.Employees;
using Payslip.Infra.Data.Contexts;
using Payslip.Infra.Data.Features.Employees;

namespace Payslip.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.LoadSettings<AppSettings>("AppSettings");

            services.AddScoped(context =>
            {
                var options = new DbContextOptionsBuilder<PayslipDbContext>().UseSqlServer(appSettings.ConnectionString).Options;
                return new PayslipDbContext(options);
            });

            services.AddDbContext<PayslipDbContext>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
