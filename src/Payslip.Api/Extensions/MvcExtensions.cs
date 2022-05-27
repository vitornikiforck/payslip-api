using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Payslip.Api.Filters;

namespace Payslip.Api.Extensions
{
    public static class MvcExtensions
    {
        public static void AddMVC(this IServiceCollection services)
        {

            services.AddMvcCore(opt => opt.Filters.Add(new ExceptionHandlerAttribute()))
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Application.AppModule>();
                })
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.Formatting = Formatting.None;
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                });

            services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}