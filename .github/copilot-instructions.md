# DemoGitHubWeb
DemoGitHubWeb is an ASP.NET Core 8.0 MVC web application that demonstrates a simple user management interface with Bootstrap styling and JavaScript-based inline editing functionality.

**ALWAYS reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.**

## Working Effectively
- Bootstrap, build, and run the repository:
  - `cd /path/to/repo/DemoGitHubWeb/DemoGitHubWeb`
  - `dotnet restore` -- takes ~6 seconds
  - `dotnet build` -- takes ~12 seconds, produces no warnings or errors. NEVER CANCEL.
  - `dotnet run` -- starts development server on http://localhost:5086
- Format code: `dotnet format` -- takes ~5 seconds, automatically fixes code formatting issues
- **CRITICAL**: There are NO unit tests in this project. `dotnet test` returns immediately with no tests to run.

## Build Times and Timeout Values
- **dotnet restore**: ~6 seconds - set timeout to 60 seconds minimum
- **dotnet build**: ~12 seconds - set timeout to 120 seconds minimum  
- **dotnet run**: starts immediately - set timeout to 30 seconds for startup
- **dotnet format**: ~5 seconds - set timeout to 60 seconds minimum
- **NEVER CANCEL** any dotnet commands. Always wait for completion.

## Running the Application
- **Development server**: `dotnet run` from `DemoGitHubWeb/DemoGitHubWeb` directory
- **Application URL**: http://localhost:5086
- **Startup time**: ~2 seconds to become responsive
- **Shutdown**: Ctrl+C or SIGTERM signal

## Validation Scenarios
After making any changes, ALWAYS validate these user scenarios:
1. **Home Page Test**: 
   - Navigate to http://localhost:5086
   - Verify page title: "Home Page - DemoGitHubWeb"
   - Verify "Welcome" header is displayed
2. **User Management Test**:
   - Navigate to http://localhost:5086/User/UserList
   - Verify page title: "User Page - DemoGitHubWeb" 
   - Verify user data is displayed (should show "Nguyen Van A", "Tran Thi B", "Le Van C")
   - Test inline editing by clicking "Edit" button (JavaScript functionality)
   - Verify Bootstrap styling is applied (responsive table, buttons)

## Project Structure
- **Solution file**: `DemoGitHubWeb/DemoGitHubWeb.sln`
- **Main project**: `DemoGitHubWeb/DemoGitHubWeb/DemoGitHubWeb.csproj`
- **Target framework**: .NET 8.0 (specified in global.json: `"version": "8.0.0"`)
- **Controllers**:
  - `Controllers/HomeController.cs` - handles home page and privacy page
  - `Controllers/UserController.cs` - handles UserList action
- **Views**:
  - `Views/Home/Index.cshtml` - main landing page
  - `Views/Home/Privacy.cshtml` - privacy page
  - `Views/User/UserList.cshtml` - user management interface with inline editing
- **Models**: `Models/ErrorViewModel.cs` - error handling model

## Key Features to Test
- **Responsive UI**: Bootstrap-based responsive design
- **Inline Editing**: JavaScript-powered edit/cancel/update functionality in user table
- **Logging**: Structured logging configured (check console output during `dotnet run`)
- **Static Files**: CSS, JS, and Bootstrap libraries served from wwwroot

## Development Workflow
1. Always run `dotnet restore` after cloning or changing dependencies
2. Always run `dotnet build` to verify compilation before making changes
3. Always run `dotnet format` before committing to ensure consistent code style
4. Test both home page (/) and user management page (/User/UserList) after changes
5. Verify JavaScript functionality works in UserList page (edit buttons)

## Dependencies and Requirements
- **.NET 8.0 SDK**: Required (check with `dotnet --version`, should be 8.0.x)
- **No external databases**: Application uses hardcoded demo data
- **No authentication**: Application has no login requirements
- **Bootstrap**: Included via CDN in layout, no local installation needed

## Important Notes
- **No CI/CD pipeline**: No GitHub Actions or build automation configured
- **No tests**: Project contains no unit tests, integration tests, or test frameworks
- **Development only**: Application is configured for development environment only
- **Logging**: Uses built-in ASP.NET Core logging (console output during development)
- **HTTPS redirect**: Enabled in Program.cs but development runs on HTTP

## Common Commands Reference
```bash
# Navigate to project directory
cd /path/to/repo/DemoGitHubWeb/DemoGitHubWeb

# Full build and run sequence
dotnet restore    # ~6 seconds
dotnet build      # ~12 seconds  
dotnet run        # starts on localhost:5086

# Code formatting
dotnet format     # ~5 seconds, fixes formatting issues

# Quick validation
curl -I http://localhost:5086                 # should return HTTP 200
curl -I http://localhost:5086/User/UserList   # should return HTTP 200
```

## Troubleshooting
- **Build fails**: Check .NET 8.0 SDK is installed with `dotnet --version`
- **Port conflicts**: Application uses port 5086, ensure it's available
- **Missing packages**: Run `dotnet restore` to restore NuGet packages
- **Formatting issues**: Run `dotnet format` to auto-fix code style problems
- **Static files not loading**: Ensure wwwroot directory permissions are correct

## File Locations Quick Reference
```
DemoGitHubWeb/
├── DemoGitHubWeb.sln                          # Solution file
├── global.json                                # .NET SDK version specification  
└── DemoGitHubWeb/
    ├── DemoGitHubWeb.csproj                   # Project file
    ├── Program.cs                             # Application entry point
    ├── Controllers/
    │   ├── HomeController.cs                  # Home and Privacy actions
    │   └── UserController.cs                  # UserList action  
    ├── Models/
    │   └── ErrorViewModel.cs                  # Error handling
    ├── Views/
    │   ├── Home/
    │   │   ├── Index.cshtml                   # Main landing page
    │   │   └── Privacy.cshtml                 # Privacy page
    │   ├── User/
    │   │   └── UserList.cshtml                # User management with inline editing
    │   └── Shared/                            # Layout and shared views
    └── wwwroot/                               # Static files (CSS, JS, libraries)
```