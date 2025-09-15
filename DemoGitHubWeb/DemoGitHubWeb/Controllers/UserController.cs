using System.Diagnostics;
using DemoGitHubWeb.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

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
        _logger.LogInformation("Testing logging in UserController Index action.");
        return View();
    }

    private List<User> GetUsers()
    {
        return new List<User>
        {
            new User { STT = 1, Fullname = "Nguyen Van A", Gender = "Male", Email = "nguyenvana@example.com" },
            new User { STT = 2, Fullname = "Tran Thi B", Gender = "Female", Email = "tranthib@example.com" },
            new User { STT = 3, Fullname = "Le Van C", Gender = "Male", Email = "levanc@example.com" }
        };
    }

    public IActionResult ExportToExcel()
    {
        var users = GetUsers();

        // Set EPPlus license context
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Users");

        // Headers
        worksheet.Cells[1, 1].Value = "STT";
        worksheet.Cells[1, 2].Value = "Fullname";
        worksheet.Cells[1, 3].Value = "Gender";
        worksheet.Cells[1, 4].Value = "Email";

        // Header formatting
        using (var range = worksheet.Cells[1, 1, 1, 4])
        {
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
        }

        // Data
        for (int i = 0; i < users.Count; i++)
        {
            worksheet.Cells[i + 2, 1].Value = users[i].STT;
            worksheet.Cells[i + 2, 2].Value = users[i].Fullname;
            worksheet.Cells[i + 2, 3].Value = users[i].Gender;
            worksheet.Cells[i + 2, 4].Value = users[i].Email;
        }

        // Auto-fit columns
        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

        var stream = new MemoryStream();
        package.SaveAs(stream);
        stream.Position = 0;

        string fileName = $"UserList_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
        
        _logger.LogInformation("Exporting user list to Excel file: {FileName}", fileName);

        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}