# Nuremberg
A complete .NETCore API training project

## The full Architecture set up and installation process
- **Automapper** :  Let's start small by installling Automapper. We do this by opening the command pallette `Ctrl+Shift+P` and type in `nuget add` and then type in `Automapper`. From the dropdown list just select `Automapper`

- **Serilog** : From the command pallete install the following packages: `Serilog`, `Serilog.AspNetCore`, `Serilog.Extensions.Logging`, `Serilog.Settings.Configuration`, maybe `Serilog.Extensions.Hosting`,`Serilog.Sinks.Console`.

- **Configure Serilog for Console** : Add the settings to the `appsettings.Development.json` file. Update the `Program.cs` file to include `using Serilog` and type in `builder.Host.UseSerilog()` as in the `Program.cs` file. **NOTE** In NETCore6 a lot has changed. For more information google `setting up serilog in ASP.NETCore 6.0`

- **EntityFrameworkCore** : as usual open the command pallete and search for EntityFrameworkCore and install the following packages: `Microsoft.EntityFrameworkCore` , `Microsoft.EntityFrameworkCore.InMemory` , `Microsoft.EntityFrameworkCore.Tools` , `Microsoft.EntityFrameworkCore.Design`. Setting it all up for `Postgresql` will come at a later stage.

- **Configure EFCore** : add `ApplicationDbContext` file in Data directory and add a simple `TestModel`. Configure the AppDbContext in the `Program.cs` file. Yes, `ApplicationDbContext` class is partial so it will be easier to break up as it gets too big :)

