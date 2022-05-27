namespace Payslip.Api.Extensions
{
    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<T>(this WebApplicationBuilder appBuilder) where T : IStartup
        {
            var startup = Activator.CreateInstance(typeof(T), appBuilder.Configuration) as IStartup;

            if (startup == null)
                throw new ArgumentException("Null Startup class");

            appBuilder.AddAutofac();
            startup.ConfigureServices(appBuilder.Services);

            var app = appBuilder.Build();
            startup.Configure(app, app.Environment);

            app.Run();

            return appBuilder;
        }
    }
}