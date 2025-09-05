using System.Diagnostics;
using DemoGitHubWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoGitHubWeb.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    public IActionResult UserList()
    {
        _logger.LogInformation("Testing logging in UserController Index action.");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}