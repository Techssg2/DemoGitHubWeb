using System.Diagnostics;

namespace DemoGitHubWeb.Service;

public class Vulnerable
{
    // Lỗi 1: SQL Injection (Tiêm nhiễm SQL)
    
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
}
