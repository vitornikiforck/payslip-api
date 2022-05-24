using FluentValidation;
using MediatR;
using Payslip.Api.Behaviours;
using Payslip.Application;
using System.Reflection;

namespace Payslip.Api.Extensions
{
    public static class MediatorExtensions
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(AppModule).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));
        }
    }
}