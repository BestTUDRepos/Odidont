namespace Odidont.Models;

public class CheckResult
{
    public string Id { get; set; } = "";
    public string Message { get; set; } = "";

    //optionally links to lecture content.
    public int? LessonId { get; set; }
    public string? LessonNodeId { get; set; }
}