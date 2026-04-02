using System.Text.Json;
using Odidont.Models;

namespace Odidont.Services;

public class CheckService
{
    public async Task<(Dictionary<string, CheckQuestion>, Dictionary<string, CheckResult>)> getCheckDataAsync()
    {
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true //allows for case-insensitive property names
        };
        
        try
        {
            var jsonStream = await FileSystem.Current.OpenAppPackageFileAsync("check.json");
            var data = await JsonSerializer.DeserializeAsync<CheckDataFile>(jsonStream, options);

            if (data == null)
                return (new(), new());

            var questions = data.Questions.ToDictionary(q => q.Id);
            var results = data.Results.ToDictionary(r => r.Id);

            return (questions, results);
        }
        catch
        {
            Console.WriteLine("Oopsies, check.json could not be read...");
            return (new(), new());
        }
    }
}