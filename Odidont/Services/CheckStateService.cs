using Odidont.Models;

namespace Odidont.Services;

public class CheckStateService
{
    public List<CheckResult> FoundIssues { get; set; } = new();
    public bool IsFinished { get; set; }
}