using Microsoft.AspNetCore.Components;
using Odidont.Models;

namespace Odidont.Components.Learn;

public partial class LessonNodeView : ComponentBase
{
    [Parameter] public required Lesson Lesson { get; set; }

    [Parameter] public required LessonNode LessonNode { get; set; }

    [Parameter] public required EventCallback<LessonNode?> LessonNodeChanged { get; set; }

    private async Task ChangeLessonNodeAsync(LessonNode? lessonNode)
    {
        if (lessonNode == null)
        {
            lessonNode = LessonNode;
            lessonNode.Complete = true;
            await LessonNodeChanged.InvokeAsync(lessonNode);
            await LessonNodeChanged.InvokeAsync(null);
        }
        else
        {
            lessonNode.Complete = true;
            await LessonNodeChanged.InvokeAsync(lessonNode);
        }
    }
}