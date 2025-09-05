using System.Diagnostics;
using DemoGitHubWeb.Models;
using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;

namespace DemoGitHubWeb.Controllers;

public class UserController: Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    private List<User> GetUsers()
    {
        return new List<User>
        {
            new User { Id = 1, FullName = "Nguyen Van A", Gender = "Male", Email = "nguyenvana@example.com" },
            new User { Id = 2, FullName = "Tran Thi B", Gender = "Female", Email = "tranthib@example.com" },
            new User { Id = 3, FullName = "Le Van C", Gender = "Male", Email = "levanc@example.com" }
        };
    }

    public IActionResult UserList()
    {
        _logger.LogInformation("Testing logging in UserController Index action.");
        var users = GetUsers();
        return View(users);
    }

    public IActionResult ExportToExcel()
    {
        var users = GetUsers();
        
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("User List");
        
        // Add headers
        worksheet.Cell(1, 1).Value = "STT";
        worksheet.Cell(1, 2).Value = "Full Name";
        worksheet.Cell(1, 3).Value = "Gender";
        worksheet.Cell(1, 4).Value = "Email";
        
        // Style headers
        var headerRange = worksheet.Range(1, 1, 1, 4);
        headerRange.Style.Font.Bold = true;
        headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
        
        // Add data
        for (int i = 0; i < users.Count; i++)
        {
            worksheet.Cell(i + 2, 1).Value = users[i].Id;
            worksheet.Cell(i + 2, 2).Value = users[i].FullName;
            worksheet.Cell(i + 2, 3).Value = users[i].Gender;
            worksheet.Cell(i + 2, 4).Value = users[i].Email;
        }
        
        // Auto-fit columns
        worksheet.Columns().AdjustToContents();
        
        // Generate file
        var stream = new MemoryStream();
        workbook.SaveAs(stream);
        stream.Position = 0;
        
        string fileName = $"UserList_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
        
        return File(stream.ToArray(), 
                   "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                   fileName);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}