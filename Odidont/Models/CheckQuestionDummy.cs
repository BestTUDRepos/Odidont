using System.Text;

namespace Odidont.Models;

public class CheckQuestionDummy
{
    public required string Question {get; set;}
    public required List<string> Options {get; set;}
    public string? SelectedOption { get; set; } = null;

    public static List<CheckQuestionDummy> GetQuestions()
    {
        StringBuilder question = new("Are you GDPR compliant");
        List<string> options = ["Yes", "No", "Maybe", "Prob not"];
        
        List<CheckQuestionDummy> questions = [];
        for (var i = 0; i < 12; i++)
        {
            questions.Add(new CheckQuestionDummy {Question = question.Append('?', 1).ToString(), Options = options});
        }
        return questions;
    }
    
    public static List<CheckQuestionDummy> UpdateQuestions(List<CheckQuestionDummy> questions)
    {
        return questions;
    }
}