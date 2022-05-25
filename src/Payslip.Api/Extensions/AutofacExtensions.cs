using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Payslip.Api.Extensions
{
    public static class AutofacExtensions
    {
        public static void AddAutofac(this WebApplicationBuilder webAppBuilder)
        {
            webAppBuilder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.AddMediator();
            });
        }
    }
}
