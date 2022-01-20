# Nuremberg
A complete .NETCore API training project

## The full Architecture set up and installation process
- **Automapper** :  Let's start small by installling Automapper. We do this by opening the command pallette `Ctrl+Shift+P` and type in `nuget add` and then type in `Automapper`. From the dropdown list just select `Automapper`

- **Serilog** : From the command pallete install the following packages: `Serilog`, `Serilog.AspNetCore`, `Serilog.Extensions.Logging`, `Serilog.Settings.Configuration`, maybe `Serilog.Extensions.Hosting`,`Serilog.Sinks.Console`.

- **Configure Serilog for Console** : Add the settings to the `appsettings.Development.json` file. Update the `Program.cs` file to include `using Serilog` and type in `builder.Host.UseSerilog()` as in the `Program.cs` file. **NOTE** In NETCore6 a lot has changed. For more information google `setting up serilog in ASP.NETCore 6.0`
- **EntityFrameworkCore** : as usual open the command pallete and search for EntityFrameworkCore and install the following packages: `Microsoft.EntityFrameworkCore` , `Microsoft.EntityFrameworkCore.InMemory` , `Microsoft.EntityFrameworkCore.Tools` , `Microsoft.EntityFrameworkCore.Design`. Setting it all up for `Postgresql` will come at a later stage.

- **Configure EFCore** : add `ApplicationDbContext` (name it as you wish) file in Data directory and add a simple `TestModel`. Configure the AppDbContext in the `Program.cs` file. Yes, `ApplicationDbContext` class is partial so it will be easier to break up as it gets too big :). More info in this tutorial:  
    > https://www.youtube.com/watch?v=nN9jOORIFtc&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=47

- **First Migrations** : install `Microsoft.EntityFrameworkCore.Sqlit` (this time I used `dotnet add package <package>`). Modify the dbContext configuration in `Program.cs` file. Run `dotnet ef migrations add InitialCreate --output-dir Data/Migrations` and voila! this worked for me. Also, I had to add a `Guid Id` to the model because EFCore was complaining that I was lacking the primary key
    > options => options.UseSqlite(@"DataSource=test.db"));

-  **PostgresQL Setup** : Configure the connection string using the `appsettings.Development.json` file. 
Install `Npgsql.EntityFrameworkCore.PostgreSQL` package. In `Program.cs` you will need to specify the connetion string to use as specified in `appsettings.Development.json` file.

   > options => options.UseNpgsql(builder.Configuration.GetConnectionString("NurembergDb")));

   Run `database ef database update`

