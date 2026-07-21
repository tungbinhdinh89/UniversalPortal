using Scalar.AspNetCore;
using UniversalPortal.API;
using UniversalPortal.Application.Interfaces;
using UniversalPortal.Infra;
using UniversalPortal.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddInfraServices(builder.Configuration)
                .AddMasterTenantServices(builder.Configuration)
                .AddWebServices(builder.Configuration);
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
