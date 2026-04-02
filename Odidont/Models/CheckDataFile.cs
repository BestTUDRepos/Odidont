namespace Odidont.Models;

public class CheckDataFile
{
    public List<CheckQuestion> Questions { get; set; } = new();
    public List<CheckResult> Results { get; set; } = new();
}