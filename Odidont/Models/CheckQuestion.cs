namespace Odidont.Models;

public class CheckQuestion
{
    public string Id { get; set; } = "";
    public string Text { get; set; } = "";

    public List<CheckOption> Options { get; set; } = new();
}