# Nuremberg
A complete .NETCore API training project

## The full Architecture set up and installation process
- **AutoMapper** :  Let's start small by installling AutoMapper. We do this by opening the command pallette `Ctrl+Shift+P` and type in `nuget add` and then type in `Automapper.` From the dropdown list just select `AutoMapper`. Additionally, install the `AutoMapper.Extensions.Microsoft.DependencyInjection`. In the `Program.cs` you will need to inject the service: `builder.Services.AddAutoMapper(typeof(AutoMapperProfile));`. The Profile file you will have to manually create yourself. The Data folder would be a nice place to put the file.

- **Serilog** : From the command pallete install the following packages: 
    1. `Serilog`, 
    2. `Serilog.AspNetCore`,
    3. `Serilog.Extensions.Logging`, 
    4. `Serilog.Settings.Configuration`
    5.  and maybe `Serilog.Extensions.Hosting`,`Serilog.Sinks.Console`.

- **Configure Serilog for Console** :
    1. Add the settings to the `appsettings.Development.json` file.
    2. Update the `Program.cs` file to include `using Serilog` and type in `builder.Host.UseSerilog()` as in the `Program.cs` file. 

     **NOTE** In NETCore6 a lot has changed. For more information google `setting up serilog in ASP.NETCore 6.0`

- **EntityFrameworkCore** :Install the following packages:    
    1. `Microsoft.EntityFrameworkCore` ,
    2. `Microsoft.EntityFrameworkCore.InMemory` ,
    3. `Microsoft.EntityFrameworkCore.Tools` ,
    4. `Microsoft.EntityFrameworkCore.Design`. 
    * Setting it all up for `Postgresql` will come at a later stage.



- **Configure EFCore** : add `ApplicationDbContext` (name it as you wish) file in Data directory and add a simple `TestModel`. Configure the AppDbContext in the `Program.cs` file. Yes, `ApplicationDbContext` class is partial so it will be easier to break up as it gets too big :). More info in this tutorial:  
    > https://www.youtube.com/watch?v=nN9jOORIFtc&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=47

- **First Migrations** : install `Microsoft.EntityFrameworkCore.Sqlit` (this time I used `dotnet add package <package>`). Modify the dbContext configuration in `Program.cs` file. Run `dotnet ef migrations add InitialCreate --output-dir Data/Migrations` and voila! this worked for me. Also, I had to add a `Guid Id` to the model because EFCore was complaining that I was lacking the primary key
    > options => options.UseSqlite(@"DataSource=test.db"));

-  **PostgresQL Setup** : Configure the connection string using the `appsettings.Development.json` file. 
Install `Npgsql.EntityFrameworkCore.PostgreSQL` package. In `Program.cs` you will need to specify the connetion string to use as specified in `appsettings.Development.json` file.

    > options => options.UseNpgsql(builder.Configuration.GetConnectionString("NurembergDb")));

    * Run `database ef database update`

8. **Postgresql in Docker container**: create a `docker-compose.yml` file and add the content as specified. Run `database ef database update` which will add the db to the postgres server running in the container. To view in PgAdmin create a new server with the required details: localhost, port 5433, disable SSH and database name and password. After running the dotnet ef command refresh pgAdmin and you should have the db in there :)

9. **Seeding the database** To seed the `TestModels` table with some fake data we use the `override void OnModelCreating()` for this. Add some instances of the model and run a new migration: `dotnet ef migrations add SeedData` and then run `dotnet ef database update`. Verify the table has this data added to it.

10. **Identity from EFCore** : add the nuget package `Microsoft.AspNetCore.Identity.EntityFrameworkCore`. The `ApplicationDbContext` must now extend the IdentityDbContext class instead of the DbContext class. This must be done for all partial ApplicationDbContext classes. Add the service in `Program.cs` file in the dbContext section : `builder.Services.AddIdentity<IdentityUser, IdentityRole>()`

11. ** xUnit ** : for Version 2.0 only. Adding a separate project with `dotnet new xunit -o Nuremberg.Api.Tests`. 

## What's next ##
- Add ErrorHandlingMiddleware
- Redis caching : watch Chapras and Tim tutorials
- Add unit testing framework XUnit - dotnet new xunit -o nuremberg.test for example
- Research other project structure or layouts
