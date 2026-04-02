using Microsoft.AspNetCore.Components;
using Odidont.Models;
using Odidont.Services;

namespace Odidont.Components.Pages;

public partial class Learn : ComponentBase
{
    [SupplyParameterFromQuery(Name = "lessonId")]
    public int? QueryLessonId { get; set; }

    [SupplyParameterFromQuery(Name = "nodeId")]
    public string? QueryNodeId { get; set; }
    
    private Lesson? SelectedLesson { get; set; }
    private LessonNode? SelectedLessonNode { get; set; }
    
    private List<Lesson> Lessons { get; set; } = new();

    [Inject]
    private LessonService LessonService { get; set; } = null!;
    
    protected override async Task OnInitializedAsync()
    {
        Lessons = await LessonService.GetLessonsAsync();

        // Use the Query properties we defined above
        if (QueryLessonId.HasValue)
        {
            SelectedLesson = Lessons.FirstOrDefault(l => l.Id == QueryLessonId.Value);
            
            if (SelectedLesson != null && !string.IsNullOrEmpty(QueryNodeId))
            {
                if (SelectedLesson.Nodes.TryGetValue(QueryNodeId, out var node))
                {
                    SelectedLessonNode = node;
                }
            }
        }
    }
    
    private void LessonChangedCallback(Lesson? lesson)
    {
        SelectedLesson = lesson;
        if (SelectedLesson == null || (SelectedLessonNode != null && !SelectedLesson.ContainsNode(SelectedLessonNode)))
        {
            SelectedLessonNode = null;
        }
    }
    
    private void LessonNodeChangedCallback(LessonNode? lessonNode)
    {
        if (SelectedLesson == null || (SelectedLessonNode != null && !SelectedLesson.ContainsNode(SelectedLessonNode)))
        {
            SelectedLessonNode = null;
            return;
        }

        SelectedLessonNode?.Complete = true;
        SelectedLessonNode = lessonNode;
    }
}