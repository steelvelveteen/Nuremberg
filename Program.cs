using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure application dbcontext
builder.Services.AddDbContext<ApplicationDbContext>(
    // options => options.UseSqlite(@"DataSource=test.db"));
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("NurembergDb")));

// Serilog
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console()
);

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

app.Run();
