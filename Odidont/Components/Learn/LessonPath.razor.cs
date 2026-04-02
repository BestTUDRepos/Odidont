using Microsoft.AspNetCore.Components;
using Odidont.Models;

namespace Odidont.Components.Learn;

public partial class LessonPath : ComponentBase
{
    [Parameter]
    public required Lesson Lesson { get; set; }
    
    [Parameter] 
    public required EventCallback<LessonNode?> LessonNodeChanged { get; set; }

    private async Task ChangeLessonNodeAsync(LessonNode lessonNode)
    {
        await LessonNodeChanged.InvokeAsync(lessonNode);
    }
    
    private string DisabledNode(bool disabled)
    {
        return disabled ? "opacity-50" : ""; // only looks disabled, but is actually clickable
    }
    
    private string DisabledPathStyle(bool disabled)
    {
        return disabled ? "" : "width:3px;";
    }

    private string CompleteNode(LessonNode lessonNode)
    {
        return lessonNode.Complete
            ? "secondary"
            : "primary";
    }

    private string CompletePathClass(LessonNode lessonNode)
    {
        if (lessonNode.Complete)
        {
            return "border-3";
        }

        return "";
    }
    
    private string CompletePathStyle(LessonNode lessonNode)
    {
        if (lessonNode.Complete)
        {
            return "width:3px;";
        }

        return "";
    }


    private int CompleteCountFrom(LessonNode lessonNode)
    {
        if (!lessonNode.Complete)
        {
            return 0;
        }

        return 1 + lessonNode.Next.Sum(CompleteCountFrom);
    }

    private int CompleteCount()
    {
        return CompleteCountFrom(Lesson.StartNode);
    }

    private int CountFrom(LessonNode lessonNode)
    {
        return 1 + lessonNode.Next.Sum(CountFrom);
    }

    private int Count()
    {
        return CountFrom(Lesson.StartNode);
    }

    private int Progress()
    {
        return (int)((float)CompleteCount() / Count() * 100);
    }
}