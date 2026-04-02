using Microsoft.AspNetCore.Components;
using Odidont.Models;

namespace Odidont.Components.Learn;

public partial class QuizView
{
    [Parameter] public required List<QuizData> Quiz { get; set; }
    
    [Parameter] 
    public required EventCallback<LessonNode?> LessonNodeChanged { get; set; }

    private async Task ChangeLessonNodeAsync(LessonNode? lessonNode)
    {
        await LessonNodeChanged.InvokeAsync(lessonNode);
    }
    
    private int _currentQuizId;
    private QuizData? _currentQuiz;

    private QuizOption? _selectedOption;
    
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Quiz.Count == 0) return;
        if (_currentQuizId >= Quiz.Count) return;

        _currentQuiz = Quiz[_currentQuizId];
        
    }

    private void Select(QuizOption option)
    {
        _selectedOption = option;
    }

    private string NextString()
    {
        if (_currentQuiz == null) return "";
        if (_currentQuizId >= Quiz.Count) return "";
        return _currentQuizId == Quiz.Count - 1 ? "Return to Overview" : "OK";
    }

    private async Task NextAsync()
    {
        if (_currentQuiz == null)
        {
            _currentQuizId = -1;
        }

        _currentQuizId++;

        if (_currentQuizId >= Quiz.Count)
        {
            await ChangeLessonNodeAsync(null);
            _selectedOption = null;
            return;
        }
        
        _currentQuiz = Quiz[_currentQuizId];
        _selectedOption = null;
    }
}