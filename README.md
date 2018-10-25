# Bob Ross System for NSS Students

## Project Details

### Platform

These projects were written for the .NET Core platform.

* .NET Core version 2.1
* SQLite database

### Web API

The API was created with the following command.

```sh
dotnet new webapi -n MusicAPI --auth Individual
```

## API Setup

```sh
cd MusicAPI
dotnet restore
```

If you want to run on Windows and SQL Server, you need to delete the existing migration and create your own.

```sh
rm -rf Migrations
dotnet ef migrations add InitialSetup
dotnet ef database update
```




These steps need to happen for both the API and the Web Application projects.

Install the global Code Generation Tool for ASP.NET by visiting the [NuGet package page](https://www.nuget.org/packages/dotnet-aspnet-codegenerator/) and running the command shown there.

```sh
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Tools
```

Then you need to modify your `.csproj` file to include the command line tooling for ASP.NET scaffolding. Add the following section.

```xml
  <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="2.0.4" />
  </ItemGroup>
```

