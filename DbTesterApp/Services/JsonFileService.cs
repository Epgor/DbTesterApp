using Newtonsoft.Json;

namespace DbTesterApp.Services;

public class JsonFileService
{
    public JsonFileService() { }

    public readonly string booksPath = "C:\\Users\\user\\source\\repos\\DbTesterApp\\DbTesterApp\\Files\\storeBooks.json";
    public readonly string workersPath = "C:\\Users\\user\\source\\repos\\DbTesterApp\\DbTesterApp\\Files\\storeWorkers.json";
    public readonly string librariesPath = "C:\\Users\\user\\source\\repos\\DbTesterApp\\DbTesterApp\\Files\\storeLibraries.json";
    public readonly string organizationsPath = "C:\\Users\\user\\source\\DbTesterApp\\DbTesterApp\\Files\\storeOrganizations.json";
    public readonly string numbersPath = "C:\\Users\\user\\source\\repos\\DbTesterApp\\DbTesterApp\\Files\\storeNumbers.json";
    public readonly string pointsPath = "C:\\Users\\user\\source\\repos\\DbTesterApp\\DbTesterApp\\Files\\storePoints.json";
    public readonly string vectorsPath = "C:\\Users\\user\\source\\repos\\DbTesterApp\\DbTesterApp\\Files\\storeVectors.json";
    public async Task<int> SaveToFile<T>(T items, string path)
    {
        try
        {
            var jsonItems = JsonConvert.SerializeObject(items, Formatting.Indented);
            using (var writer = new StreamWriter(path))
            {
                writer.Write(jsonItems);
            }
        }
        catch (Exception e){ Console.WriteLine(e.Message); } return 0;
    }

    public async Task<T> ReadFromFile<T>(string path)
    {
        try 
        {
            using (var reader = new StreamReader(path))
            {
                var jsonItems = await reader.ReadToEndAsync();
                var returnItems = JsonConvert.DeserializeObject<T>(jsonItems);
                if (returnItems == null)
                    throw new Exception($"Empty result");
                return returnItems;
            }
        }
        catch (Exception e) { Console.WriteLine(e.Message); throw new Exception($"{e}"); };
    }
}
