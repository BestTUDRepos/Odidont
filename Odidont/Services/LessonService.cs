using System.Text.Json;
using System.Text.Json.Serialization;
using Odidont.Models;

namespace Odidont.Services;

public class LessonService
{
    public async Task<List<Lesson>> GetLessonsAsync()
    {
        // return DummyLectures();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, //allows for case-insensitive property names
            
            //https://stackoverflow.com/questions/40811837/json-deserialization-with-enum-types#40811935
            Converters = { new JsonStringEnumConverter() }
        };

        List<Lesson>? lessons = null;
        try
        {
            var jsonStream = await FileSystem.Current.OpenAppPackageFileAsync("lessons.json");
            lessons = await JsonSerializer.DeserializeAsync<List<Lesson>>(jsonStream, options);
        }
        catch
        {
            // TODO: Add logging, file opening went badge
            Console.WriteLine("Oopsies, lessons.json could not be read...");
        }


        return lessons ?? new List<Lesson>();
    }
    
    

    private List<Lesson> DummyLectures()
    {
        var lipsum =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        var node1 = new LessonNode
        {
            Id = "1",
            Content = lipsum,
            NextNodeIds = new List<string> { "2" }
        };

        var node2 = new LessonNode
        {
            Id = "2",
            Content = lipsum,
            NextNodeIds = new List<string> { "3" }
        };

        var node3 = new LessonNode
        {
            Id = "3",
            Content = lipsum,
            NextNodeIds = new List<string>()
        };

        return new List<Lesson>
        {
            new Lesson
            {
                Id = 1,
                Title = "GDPR Basics",
                Description = "Intro to GDPR",
                StartNodeId = "1",
                Nodes = new Dictionary<string, LessonNode>
                {
                    { node1.Id, node1 },
                    { node2.Id, node2 },
                    { node3.Id, node3 }
                }
            }
        };
    }
}