using DbTesterApp.Models.Sql;
namespace DbTesterApp.Services;

public class DataPreparationService
{
    private readonly HashIdentifierService hashIdentifierService;
    public DataPreparationService(HashIdentifierService hashIdentifierService)
    {
        this.hashIdentifierService = hashIdentifierService;
    }
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
        var books = GenerateBook(booksQuantity);
        //wokers
        var workers = GenerateWorker(workersQuantity);
        //numbers
        var numbers = GenerateNumber(numbersQuantity);
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
        var organisation = GenerateOrganization();
        ///////////////////////////////////////////////////////////////////////////
        //
        //Data for main test
        //organisations
        var organisations = GenerateOrganization(organizationsQuantity);
        //vectors
        var vectors = GenerateVector(vectorsQuantity);

        ///////////////////////////////////////////////////////////////////////////
    }
    private async Task<List<Book>> GenerateBook(int quantity = 1)
    {
        var books = new List<Book>();
        for (int i = 0; i < quantity; i++)
        {
            var id = hashIdentifierService.GetHashId();
            var book = await BookGenerator.GetBook(id);
            books.Add(book);
            RefreshProgress(i, quantity, refreshRate);
        }
        //Console.Clear();
        Console.WriteLine("Completed generating books");
        return books;
    }
    private async Task<List<Number>> GenerateNumber(int quantity = 1)
    {
        var numbers = new List<Number>();
        for (int i = 0; i < quantity; i++)
        {
            var id = hashIdentifierService.GetHashId();
            var number = await NumberGenerator.GetNumber(id);
            numbers.Add(number);
            RefreshProgress(i, quantity, refreshRate);
        }
        //Console.Clear();
        Console.WriteLine("Completed generating numbers");
        return numbers;
    }
    private async Task<List<Worker>> GenerateWorker(int quantity = 1)
    {
        var workers = new List<Worker>();
        for (int i = 0; i < quantity; i++)
        {
            var id = hashIdentifierService.GetHashId();
            var worker = await WorkerGenerator.GetWorker(id);
            workers.Add(worker);
            RefreshProgress(i, quantity, refreshRate);
        }
        //Console.Clear();
        Console.WriteLine("Completed generating workers");
        return workers;
    }
    private async Task<List<Point>> GeneratePoint(int quantity = 1)
    {
        var points = new List<Point>();
        for (int i = 0; i < quantity; i++)
        {
            var id = hashIdentifierService.GetHashId();
            var point = await PointGenerator.GetPoint(id, GenerateNumber(numbersPerPointQuantity).Result);
            points.Add(point);
        }
        return points;
    }
    private async Task<List<Vector>> GenerateVector(int quantity = 1)
    {
        var vectors = new List<Vector>();
        for (int i = 0; i < quantity; i++)
        {
            var id = hashIdentifierService.GetHashId();
            var vector = await VectorGenerator.GetVector(id, GeneratePoint(pointsPerVectorQuantity).Result);
            vectors.Add(vector);
        }
        return vectors;
    }
    private async Task<List<Library>> GenerateLibrary(int quantity = 1)
    {
        var libraries = new List<Library>();
        for (int i = 0; i < quantity; i++)
        {
            var id = hashIdentifierService.GetHashId();
            var library = 
                await LibraryGenerator.GetLibrary(
                    id,
                    GenerateWorker(workersPerLibraryQuantity).Result,
                    GenerateBook(booksPerLibraryQuantity).Result);
            libraries.Add(library);
        }
        return libraries;
    }

    private async Task<List<Organization>> GenerateOrganization(int quantity = 1)
    {
        var organizations = new List<Organization>();
        for (int i = 0; i < quantity; i++)
        {
            var id = hashIdentifierService.GetHashId();
            var library =
                await OrganizationGenerator.GetOrganization(
                    id,
                    GenerateLibrary(librariesPerOrganizationQuantity).Result,
                    GenerateWorker(workersPerOrganizationQuantity).Result);
            organizations.Add(library);
            RefreshProgress(i, quantity, refreshRate);
        }
        Console.WriteLine("Completed generating organizations");
        return organizations;
    }

    private static void RefreshProgress(int current, int total, int refreshRate)
    {
        if (current % refreshRate != 0)
            return;
        //Console.Clear();
        var progress = (decimal)current / total * 100;
        var percent = Math.Round(progress, 2);
        Console.WriteLine($"Producing: {percent}% completed\n");
    }
}
