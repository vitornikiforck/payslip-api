using FluentValidation;
using System.Reflection;

namespace Payslip.Api.Extensions
{
    public static class FluentValidationExtensions
    {
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Application.AppModule).GetTypeInfo().Assembly);
        }
    }
}
