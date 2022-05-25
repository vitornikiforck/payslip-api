using AutoMapper;

namespace Payslip.Api.Extensions
{
    public static class AutomapperExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(Startup));
                cfg.AddProfiles(typeof(Application.AppModule));
            });

            services.AddSingleton(Mapper.Instance);
        }
    }
}
