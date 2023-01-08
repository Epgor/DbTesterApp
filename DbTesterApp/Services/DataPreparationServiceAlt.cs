using DbTesterApp.Models;
using DbTesterApp.Services;

namespace DbTesterApp.Services;
/*
public class DataPreparationServiceAlt
{
    private readonly HashIdentifierService _hashIdentifierService;
    public DataPreparationServiceAlt(HashIdentifierService hashIdentifierService)
    {
        var hash = new HashIdentifierService();
        hash.GetHashId();
        _hashIdentifierService = hashIdentifierService;
    }
    //later to refactor - extract hashTab as a class
    //register as a singleton
    //extract generation callings
    //refactor to be more generic
    private int booksQuantity { get; set; }
    private int workersQuantity { get; set; }
    private int booksPerLibraryQuantity { get; set; }
    private int workersPerLibraryQuantity { get; set; }
    private int librariesPerOrganizationQuantity { get; set; }
    private int workersPerOrganizationQuantity { get; set; }
    private int organizationsQuantity { get; set; }
    private int numbersQuantity { get; set; }
    private int numbersPerPointQuantity { get; set; }
    private int pointsPerVectorQuantity { get; set; }
    private int vectorsQuantity { get; set; }
    private int refreshRate { get; set; }

    public void Configure(
        int booksQuantity = 10,
        int workersQuantity = 10,
        int booksPerLibraryQuantity = 3,
        int workersPerLibraryQuantity = 3,
        int librariesPerOrganizationQuantity = 3,
        int workersPerOrganizationQuantity = 3,
        int organizationsQuantity = 3,
        int numbersQuantity = 10,
        int numbersPerPointQuantity = 3,
        int pointsPerVectorQuantity = 3,
        int vectorsQuantity = 3,
        int refreshRate = 10) 
    {
        this.booksQuantity = booksQuantity;
        this.workersQuantity = workersQuantity;
        this.booksPerLibraryQuantity = booksPerLibraryQuantity;
        this.workersPerLibraryQuantity = workersPerLibraryQuantity;
        this.librariesPerOrganizationQuantity = librariesPerOrganizationQuantity;
        this.workersPerOrganizationQuantity = workersPerOrganizationQuantity;
        this.organizationsQuantity = organizationsQuantity;
        this.numbersQuantity = numbersQuantity;
        this.numbersPerPointQuantity = numbersPerPointQuantity;
        this.pointsPerVectorQuantity = pointsPerVectorQuantity;
        this.vectorsQuantity = vectorsQuantity;
        this.refreshRate = refreshRate;
    }


    public async Task PrepareData()
    {
        ///////////////////////////////////////////////////////////////////////////
        //Data for init test
        //books
        var books = Generate<Book>(booksQuantity);
        //wokers
        var workers = Generate<Worker>();
        //numbers
        var numbers = Generate<Number>();
        ///////////////////////////////////////////////////////////////////////////
        //
        //Data for secondary test
        //point
        var point = GeneratePoint();
        //vector
        var vector = GenerateVector();
        //library
        var library = GenerateLibrary();
        //organization
        var organisation = Generate<Organization>();
        ///////////////////////////////////////////////////////////////////////////
        //
        //Data for main test
        //organisations
        var organisations = Generate<List<Organization>>();
        //vectors
        var vectors = GenerateVector();
        //_hashIdentifierService.GetHashId();
        ///////////////////////////////////////////////////////////////////////////

    }
    private async Task<List<Book>> GenerateBook(int booksQuantity, int refreshRate)
    {
        var books = new List<Book>();
        for (int i = 0; i < booksQuantity; i++)
        {
            var id = hashIdentifierService.GetHashId();
            var book = await BookGenerator.GetBook(id);
            books.Add(book);
            RefreshProgress(i, booksQuantity, refreshRate);
        }
        //Console.Clear();
        Console.WriteLine("Completed");
        return books;
    }
    private static async Task<List<Number>> GenerateNumber(int numbersQuantity, int refreshRate)
    {
        for (int i = 0; i < numbersQuantity; i++)
        {
            var id = GetHashId(i);
            var book = NumberGenerator.GetNumber(id);
            books.Add(book);
            RefreshProgress(i, numbersQuantity, refreshRate);
        }
        //Console.Clear();
        Console.WriteLine("Completed");
        return book;
    }
    private static object GenerateWorker(int workersQuantity, int refreshRate)
    {
        throw new NotImplementedException();
    }
    private async Task<List<T>> Generate<T>(int quantity)
    {
        var result = new List<T>();
        for(int i = 0; i < quantity; i++)
        {
            var id = _hashIdentifierService.GetHashId();
            switch (typeof(T))
            {
                case Type numberType when numberType == typeof(Number):
                    return (List<T>)Convert.ChangeType(NumberGenerator.GetNumber(id, numbersQuantity), typeof(T));
                default:
                    continue;
            }
                    
        }
        return result;
    }
    private static T Type<T>(T value)
    {
        return (T)Convert.ChangeType(value, typeof(T));
    }
    private static object GenerateLibrary(int booksPerLibraryQuantity, int workersPerLibraryQuantity, int refreshRate)
    {
        throw new NotImplementedException();
    }

    private static object GenerateVector(int numbersPerPointQuantity, int pointsPerVectorQuantity, int refreshRate, int vectorsQuantity = 1)
    {
        throw new NotImplementedException();
    }

    private static object GeneratePoint(int numbersPerPointQuantity, int refreshRate)
    {
        throw new NotImplementedException();
    }



    private static void RefreshProgress(int current, int total, int refreshRate)
    {
        if (current % refreshRate != 0)
            return;
        //Console.Clear();
        var progress = (decimal)current / total * 100;
        var percent = Math.Round(progress, 2);
        Console.WriteLine($"Producing books: {percent}% completed\n");
    }
}
*/