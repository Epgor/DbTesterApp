using Bogus;
using DbTesterApp.Models;
using System.Net.WebSockets;
using System.Text;

namespace DbTesterApp.Services;

public class DataPreparationService
{
    public DataPreparationService()  {}

    private char[] hashTab = PopulateHashTab();

    private void CheckSize(char c, int localId)
    {
        if (c == 'Z' & localId == 0)
            throw new Exception("Max size exceeded");
    }
    private string GetHashId(int id)
    {
        var localId = hashTab.Length - 1;
        while(hashTab[localId] == 'F')
        {
            CheckSize(hashTab[localId], localId);

            hashTab[localId] = '0';
            localId--;
        }

        hashTab[localId] = (char)(hashTab[localId]+1);

        return new string(hashTab);
    }

    private static char[] PopulateHashTab()
    {
        var _hashTab = new char[24];
        for(int i = 0; i < 24; i++)
        {
            _hashTab[i] = 'A';
        }
        return _hashTab;
    }

    private async Task<Book> GetBook(string id, int quantity = 1)
    {
        var book = new Faker<Book>()
          .RuleFor(p => p.Id, (f, p) => p.Id = id)
          .RuleFor(p => p.BookName, (f, p) => f.Random.Words(2))
          .RuleFor(p => p.Author, (f, p) => f.Person.FullName)
          .RuleFor(p => p.Category, (f, p) => f.Music.Genre())
          .RuleFor(p => p.Price, (f, p) => f.Commerce.Price(1, 1000, 2, "$"))
          .Generate(quantity);

        return book.First();
    }
    /*
    private async Task<Worker>(string id, int quantity = 1)
    {
        var book = new Faker<Worker>()
            .
    }
    */
    public async Task<List<Book>> PrepareData(int quantity, int refreshRate)
    {
        PopulateHashTab();
        var books = new List<Book> { };

        for(int i = 0; i<quantity; i++)
        {
            var id = GetHashId(i);
            var book = await GetBook(id);
            books.Add(book);
            RefreshProgress(i, quantity, refreshRate);
        }
        //Console.Clear();
        Console.WriteLine("Completed");
        return books;
    }

    private void RefreshProgress(int current, int total, int refreshRate)
    {
        if (current % refreshRate != 0)
            return;
        //Console.Clear();
        var progress = (decimal)current / total * 100;
        var percent = Math.Round(progress, 2);
        Console.WriteLine($"Producing books: {percent}% completed\n");
    }
}
