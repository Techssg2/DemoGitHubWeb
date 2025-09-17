using System.Diagnostics;

namespace DemoGitHubWeb.Service;

public class VulnerableService
{
    // Lỗi 1: SQL Injection (Tiêm nhiễm SQL)
    
    public void GetUserData(string userName)
    {
        // LỖI: Ghép chuỗi trực tiếp, không dùng Parameter
        // CodeQL sẽ phát hiện 'userName' (nguồn) đi vào 'query' (nơi nhận nguy hiểm)
        string query = "SELECT * FROM Users WHERE UserName = '" + userName + "'";
        
    }
    public void PingAddress(string ipAddress)
    {
        // LỖI: Chạy một tiến trình với đầu vào "thô" của người dùng.
        // Người dùng có thể nhập: "8.8.8.8 && del /Q C:\*" (nếu là Windows)
        // CodeQL sẽ phát hiện 'ipAddress' được dùng trong 'Process.Start'
        Process.Start("cmd.exe", "/C ping " + ipAddress);
    }
    // Lỗi 3: Path Traversal (Lỗi đường dẫn)
    public string GetUserFile(string fileName)
    {
        // LỖI: Người dùng có thể nhập "../appsettings.json"
        string basePath = "C:\\UserUploads\\";
        string fullPath = Path.Combine(basePath, fileName);
        
        // CodeQL sẽ phát hiện 'fileName' (nguồn) 
        // đi vào 'fullPath' và được dùng trong 'File.ReadAllText' (nơi nhận nguy hiểm)
        return File.ReadAllText(fullPath);
    }
    public void ConnectToDatabase()
    {
        // LỖI: Mật khẩu nằm ngay trong code
        string dbPass = "MySuperSecretPassword@123!";
        string connectionString = "Server=db.example.com;User=admin;Password=" + dbPass;
        
        // ...
    }
}
