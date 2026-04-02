using Microsoft.AspNetCore.Components;
using Odidont.Models;
using Odidont.Services;

namespace Odidont.Components.Pages;

public partial class Check : ComponentBase
{
    private Dictionary<string, CheckQuestion> Questions = new();
    private Dictionary<string, CheckResult> Results = new();

    private CheckQuestion? SelectedQuestion;
    
    // Change: Store a list of issues found during the survey
    private List<CheckResult> FoundIssues = new();
    private bool IsFinished = false;
    
    [Inject]
    private NavigationManager Nav { get; set; } = null!;
    
    [Inject]
    private CheckService CheckService { get; set; } = null!;
    
    [Inject]
    private CheckStateService State { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        var (questions, results) = await CheckService.getCheckDataAsync();
        Questions = questions;
        Results = results;
        if (State.IsFinished)
        {
            SelectedQuestion = null;
        }
        else
        {
            SelectedQuestion = Questions["q1"];
        }
    }

    private void HandleOption(CheckOption option)
    {
        if (option.ResultId != null)
        {
            State.FoundIssues.Add(Results[option.ResultId]);
        }

        if (option.NextQuestionId != null)
        {
            SelectedQuestion = Questions[option.NextQuestionId];
        }
        else
        {
            SelectedQuestion = null;
            State.IsFinished = true;
        }
    }

    private void Restart()
    {
        State.FoundIssues.Clear();
        State.IsFinished = false;
        SelectedQuestion = Questions["q1"];
    }

    private void GoToLesson(CheckResult result)
    {
        var url = $"/learn?lessonId={result.LessonId}";
        if (!string.IsNullOrEmpty(result.LessonNodeId))
        {
            url += $"&nodeId={result.LessonNodeId}";
        }
        Nav.NavigateTo(url);
    }
}