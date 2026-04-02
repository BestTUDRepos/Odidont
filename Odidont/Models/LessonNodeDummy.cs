namespace Odidont.Models;

public class LessonNodeDummy
{
    public string Name { get; set; } = "";
    public List<LessonNodeDummy> Next { get; set; } = [];
    public string Content {get; set;} = "";

    public bool Contains(LessonNodeDummy? n)
    {
        if (n == null) return false;

        return 
            n.Name.Equals(Name) || 
            Next.Any(next => next.Contains(n));
    }

    public static LessonNodeDummy GetLesson3Nodes()
    {
        List<LessonNodeDummy> nodes = [];
        var lipsum =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        for (var i = 1; i < 7; i++)
        {
            nodes.Add(new LessonNodeDummy{Name = i.ToString(), Content = lipsum});
        }
        nodes[4].Next.Add(nodes[5]);
        nodes[3].Next.Add(nodes[4]);
        nodes[2].Next.Add(nodes[3]);
        nodes[1].Next.Add(nodes[2]);
        nodes[0].Next.Add(nodes[1]);
        return nodes[0];
    }
}