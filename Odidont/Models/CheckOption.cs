namespace Odidont.Models;

public class CheckOption
{
    public string Text { get; set; } = "";

    //answer leads to either another question, or a result.
    public string? NextQuestionId { get; set; }
    public string? ResultId { get; set; }
}