using System.Data;
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

    // Giả sử connectionString được lấy từ file config
    private string connectionString = "Server=myServer;Database=myDataBase;User Id=myUser;Password=myPassword;";

    /// <summary>
    /// PHIÊN BẢN CÓ LỖ HỔNG BẢO MẬT
    /// Lấy thông tin người dùng từ cơ sở dữ liệu bằng username.
    /// Lỗ hổng: Xây dựng câu lệnh SQL bằng cách nối chuỗi trực tiếp từ input.
    /// </summary>
    public DataTable GetUser_Vulnerable(string username)
    {
        // **LỖ HỔNG NẰM Ở ĐÂY**
        // Dữ liệu 'username' từ người dùng được nối thẳng vào câu lệnh SQL.
        string query = "SELECT UserID, FirstName, LastName, Email FROM Users WHERE Username = '" + username + "'";

        DataTable dataTable = new DataTable();
        return dataTable;
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