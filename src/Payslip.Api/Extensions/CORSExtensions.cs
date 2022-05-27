namespace Payslip.Api.Extensions
{
    public static class CORSExtensions
    {
        public static void UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .Build());
        }
    }
}