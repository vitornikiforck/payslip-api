namespace Payslip.Api.Extensions
{
    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<T>(this WebApplicationBuilder WebAppBuilder) where T : IStartup
        {
            var startup = Activator.CreateInstance(typeof(T), WebAppBuilder.Configuration) as IStartup;

            if (startup == null)
                throw new ArgumentException("Null Startup class");

            startup.ConfigureServices(WebAppBuilder.Services);

            var app = WebAppBuilder.Build();
            startup.Configure(app, app.Environment);

            app.Run();

            return WebAppBuilder;
        }
    }
}