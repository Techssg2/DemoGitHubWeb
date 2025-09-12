using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoGitHubWeb.Models;

namespace DemoGitHubWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public void ConnectToExternalServices_Insecure()
    {
        // **LỖ HỔNG LỘ BÍ MẬT**
        // Các khóa API không bao giờ được lưu trữ trực tiếp trong code.
        string googleApiKey = "AIzaSyB-m_...[a_fake_google_api_key]...-z8A"; // Định dạng khóa Google API
        string githubToken = "ghp_...[a_fake_github_personal_access_token]..."; // Định dạng GitHub PAT
        string awsAccessKey = "AKIAIOSFODNN7EXAMPLE"; // Định dạng khóa truy cập AWS

        // Giả lập việc sử dụng các khóa này
        Console.WriteLine("Connecting to Google with key: " + googleApiKey);
        Console.WriteLine("Connecting to GitHub with token: " + githubToken);
        Console.WriteLine("Connecting to AWS with key: " + awsAccessKey);
        
        // Cách làm đúng: Tải các khóa từ một nơi an toàn như Azure Key Vault, AWS Secrets Manager, hoặc biến môi trường.
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Testing logging in HomeController Index action.");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}