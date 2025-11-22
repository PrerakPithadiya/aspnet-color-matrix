# Color Matrix

Interactive color matrix visualizer built with ASP.NET Core (.NET 10).

## Description

Color Matrix is an interactive web app that lets you generate, view and experiment with color matrices (grids) in the browser. It is implemented as an ASP.NET Core web application and intended as a demo, teaching aid, or UI experiment to visualize color transformations.

## Features

- Interactive color-grid visualizer
- Simple UI built with Razor Pages and static assets in `wwwroot`
- Ready to run with the .NET 10 SDK

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com) (install from the official site)

## Quick start

Open a PowerShell terminal and run:

```powershell
cd 'H:\Projects\color-matrix\WebApplication1'
dotnet restore
dotnet build
dotnet run
```

After the app starts, open the URL shown in the console (usually `https://localhost:5001` or `http://localhost:5000`).

## Development

- Source files are under the `Pages` and `wwwroot` folders. Static assets are in `wwwroot/js` and `wwwroot/css`.
- The project file is `WebApplication1.csproj`.

## Project structure

- `Pages/` — Razor Pages and page models
- `wwwroot/` — static assets (CSS, JS, libs)
- `Program.cs` — application startup
- `appsettings.json` — configuration

## License

Choose a license for your repository (e.g., MIT). This README does not add a license file — add one if you want to grant reuse rights.

---

If you want, I can initialize a local git repository, add these files, and prepare an initial commit and push instructions (or push for you if you give permission). Which would you prefer?
