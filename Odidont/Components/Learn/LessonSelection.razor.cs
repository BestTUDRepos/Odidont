using Microsoft.AspNetCore.Components;
using Odidont.Models;

namespace Odidont.Components.Learn;

public partial class LessonSelection : ComponentBase
{
    [Parameter] public required List<Lesson> Lessons { get; set; }
    [Parameter] public required EventCallback<Lesson?> LessonChanged { get; set; }

    private async Task ChangeLessonAsync(Lesson lesson)
    {
        await LessonChanged.InvokeAsync(lesson);
    }
}