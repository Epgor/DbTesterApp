using DbTesterApp.Models;
using DbTesterApp.Models.Sql;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DbTesterApp.Services;

public class JsonFileService
{
    public JsonFileService() { }

    private readonly string booksPath = "C:\\Users\\user\\source\\repos\\Epgor\\DbTesterApp\\DbTesterApp\\Files\\storeBooks.json";
    public async Task<int> SaveToFile(List<BookSql> books, string fileName)
    {
        try
        {
            var jsonBooks = JsonConvert.SerializeObject(books, Formatting.Indented);

            using (var writer = new StreamWriter(booksPath))
            {
                writer.Write(jsonBooks);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return 0;
    }

    public int ReadFromFile()
    {
        return 0;
    }
}
