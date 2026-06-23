using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using UniversalPortal.Application.Interfaces;
using UniversalPortal.Application.Services;
using UniversalPortal.Infra.Db;
using UniversalPortal.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<ApplicationSetting>(builder.Configuration.GetSection("ApplicationSetting"));
// var applicationSetting = builder.Configuration.GetSection("ApplicationSetting").Get<ApplicationSetting>();

builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    var applicationSetting = sp.GetRequiredService<IOptions<ApplicationSetting>>().Value;

    options.UseSqlServer(applicationSetting.DbConnectionString);
});
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Maps Scalar at /scalar by default
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
