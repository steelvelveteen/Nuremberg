using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nuremberg.Data;
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


// Serilog
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console()
);

var app = builder.Build();

// Middleware
app.UseMiddleware<Nuremberg.ErrorHandlingMiddleware>();

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
