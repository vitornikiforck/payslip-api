using Microsoft.OpenApi.Models;
using Payslip.Api.Extensions;
using Payslip.Infra.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper();
builder.Services.AddCors();
builder.Services.AddHealthCheckSMiddleware<PayslipDbContext>();
builder.Services.AddDependecies(builder.Configuration);

builder.Services.AddMVC();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payslip.Api", Version = "v1" })
);

//MediatorExtensions.AddMediator();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

HealthChecksExtensions.UseHealthChecksMiddleware(app);

app.UseHealthChecksMiddleware();

app.UseCorsConfig();

app.ApplyMigrations();

app.Run();
