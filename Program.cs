﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nuremberg;
using Nuremberg.Data;
using Nuremberg.Interfaces;
using Nuremberg.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure application dbcontext
builder.Services.AddDbContext<ApplicationDbContext>(
    // options => options.UseSqlite(@"DataSource=test.db"));
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("NurembergConnectionString")));

// builder.Services.AddIdentity<IdentityUser, IdentityRole>();

// Interfaces - Services
builder.Services.AddSingleton<ICacheService, CacheService>();



// Configure caching
builder.Services.AddStackExchangeRedisCache(options =>
{
    // options.Configuration = builder.Configuration.GetConnectionString("RedisConnectionString");
    // options.InstanceName = "Nuremberg";
    options.Configuration = $"{builder.Configuration.GetValue<string>("Redis:Server")}:{builder.Configuration.GetValue<int>("Redis:Port")}";
    options.InstanceName = "Nuremberg";
});


// Serilog
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console()
);

var app = builder.Build();

// Middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();