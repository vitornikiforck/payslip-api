namespace Payslip.Api
{
    public interface IStartup
    {
        public IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);
    }
}