using Microsoft.OpenApi.Models;
using Payslip.Api.Extensions;
using Payslip.Infra.Data.Contexts;

namespace Payslip.Api
{
    public class Startup : IStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payslip.Api", Version = "v1" })
            );

            services.AddMediator();
            services.AddAutoMapper();
            services.AddCors();
            services.AddHealthChecksMiddleware<PayslipDbContext>();
            services.AddDependecies(Configuration);
            services.AddMVC();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCorsConfig();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseHealthChecksMiddleware();

            app.ApplyMigrations();
        }
    }
}