namespace Odidont.Models;

public class QuizData
{
    public string Question { get; set; } = "";
    public List<QuizOption> Options { get; set; } = new();
}