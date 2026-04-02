namespace Odidont.Models;

public class LessonNode : ICloneable
{
    public enum LessonNodeType
    {
        Content,
        Quiz
    }
    
    public string Id { get; set; } = "";
    public LessonNodeType Type { get; set; }
    public string? Content { get; set; }
    public List<string> Resources { get; set; } = new();
    public List<QuizData>? Quiz { get; set; }
    
    public List<string> NextNodeIds { get; set; } = new();
    
    public List<LessonNode> Next { get; set; } = new();
    public bool Complete { get; set; } = false;
    public object Clone()
    {
        return MemberwiseClone();
    }
}