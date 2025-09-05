using System.Diagnostics;
using DemoGitHubWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoGitHubWeb.Controllers;

public class UserController: Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    public IActionResult UserList()
    {
        string userName = "JohnDoe";
        string password = "P@ssw0rd!";
        string Token = "abc123xyz456";
        _logger.LogInformation("Testing logging in UserController Index action.");
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        string keyAPI = "supersecretapikey";
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}