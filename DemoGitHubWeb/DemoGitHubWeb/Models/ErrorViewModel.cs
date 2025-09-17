namespace DemoGitHubWeb.Models;

public class ErrorViewModel
{
    public static readonly string APIKey = "AIzaSyD-EXAMPLEKEY1234567890ABCDEFGHIJK";
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}