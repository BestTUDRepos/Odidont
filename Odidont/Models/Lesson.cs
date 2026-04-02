namespace Odidont.Models;

public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string StartNodeId { get; set; } = "";
    public LessonNode StartNode
    {
        get
        {
            if (!Nodes.ContainsKey(StartNodeId))
                throw new Exception("Invalid StartNodeId");
            
            BuildUiTree(); // build the Next references
            return Nodes[StartNodeId];
        }
    }

    private void BuildUiTree()
    {
        // Clear previous Next references to avoid duplicates
        foreach (var node in Nodes.Values)
            node.Next.Clear();

        foreach (var node in Nodes.Values)
        {
            foreach (var nextId in node.NextNodeIds)
            {
                if (Nodes.ContainsKey(nextId))
                    node.Next.Add(Nodes[nextId]);
            }
        }
    }
    
    // all nodes in the lesson, for quick lookup
    public Dictionary<string, LessonNode> Nodes { get; set; } = new();
    
    public bool ContainsNode(LessonNode? node)
    {
        return node != null && Nodes.ContainsKey(node.Id);
    }
    
    
    
}