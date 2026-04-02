namespace Odidont.Models;


public class LessonDummy
{
    public required string Name { get; init; }
    public required string Tag { get; init; }
    public required string LessonPathHref { get; init; }
    public string Desc { get; init; } = "";
    public LessonNodeDummy Nodes { get; init; } = new();
    
    public static List<LessonDummy> GetLessons()
    {
        return [
            new()
            {
                Name="Lecture 1",
                Tag="One",
                LessonPathHref="",
                Desc="",
            },
            new()
            {
                Name="Lecture 2",
                Tag="Two",
                LessonPathHref="",
                Desc="",
            },
            new()
            {
                Name="Lecture 3",
                Tag="Three",
                LessonPathHref="",
                Desc="Bla bla bla\nbls;knsaldjfnaljdfalknfaksdf\nksdhlae aaefhlqe aoidfjaidjf\naliljdflajdf lasdfj",
                Nodes = LessonNodeDummy.GetLesson3Nodes()
            },
            new()
            {
                Name="Lecture 4",
                Tag="Four",
                LessonPathHref="",
                Desc="",
            },
            new()
            {
                Name="Lecture 5",
                Tag="Five",
                LessonPathHref="",
                Desc="",
            },
            new()
            {
                Name="Lecture 6",
                Tag="Six",
                LessonPathHref="",
                Desc="",
            }
        ];
    }
}
