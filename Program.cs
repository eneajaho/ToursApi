using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToursApi.Entities;
using ToursApi.Extensions;
using ToursApi.Helpers;
using ToursApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddApplicationServices(configuration);

builder.Services.AddDataProtection();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", x =>
        x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

builder.Services.AddIdentityServices(configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// this will migrate the database everytime the app is built
app.MigrateDatabase<DataContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

// app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
