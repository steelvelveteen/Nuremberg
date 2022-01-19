# Nuremberg
A complete .NETCore API training project

## The full Architecture set up and installation process
- **Automapper** :  Let's start small by installling Automapper. We do this by opening the command pallette `Ctrl+Shift+P` and type in `nuget add` and then type in `Automapper`. From the dropdown list just select `Automapper`

- **Serilog** : From the command pallete install the following packages: `Serilog`, `Serilog.AspNetCore`, `Serilog.Extensions.Logging`, `Serilog.Settings.Configuration`, maybe `Serilog.Extensions.Hosting`,`Serilog.Sinks.Console`.

- **Configure Serilog for Console** : Add the settings to the `appsettings.Development.json` file. Update the `Program.cs` file to include `using Serilog` and type in `builder.Host.UseSerilog()` as in the `Program.cs` file. **NOTE** In NETCore6 a lot has changed. For more information google `setting up serilog in ASP.NETCore 6.0`

