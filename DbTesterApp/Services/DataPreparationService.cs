using AutoMapper;
using DbTesterApp.DTO;
using DbTesterApp.Models.NoSql;
using DbTesterApp.Models.Sql;
namespace DbTesterApp.Services;

public class DataPreparationService
{
    private readonly HashIdentifierService hashIdentifierService;
    private readonly IMapper mapper;
    private readonly JsonFileService fileService;
    public DataPreparationService(HashIdentifierService hashIdentifierService, IMapper mapper, JsonFileService fileService)
    {
        this.hashIdentifierService = hashIdentifierService;
        this.mapper = mapper;
        this.fileService = fileService;
}
    //extract generation callings
    //refactor to be more generic
    private int booksQuantity { get; set; } = 2;
    private int workersQuantity { get; set; } = 2;
    private int booksPerLibraryQuantity { get; set; } = 2;
    private int workersPerLibraryQuantity { get; set; } = 2;
    private int librariesPerOrganizationQuantity { get; set; } = 2;
    private int librariesQuantity { get; set; } = 2;
    private int workersPerOrganizationQuantity { get; set; } = 2;   
    private int organizationsQuantity { get; set; } = 2;
    private int numbersQuantity { get; set; } = 2;
    private int numbersPerPointQuantity { get; set; } = 2;
    private int pointsPerVectorQuantity { get; set; } = 2;
    private int pointsQuantity { get; set; } = 2;
    private int vectorsQuantity { get; set; } = 2; 
    private int refreshRate { get; set; } = 1;

    List<Number> numberFast;
    List<Point> pointFast;
    List<Worker> workerFast;
    List<Book> bookFast;
    List<Library> libraryFast;

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

    public async Task<DataHolder> PrepareData()
    {
        var numbers = await GenerateNumber(numbersQuantity);
        //var numberNoSql = mapper.Map<List<NumberNoSql>>(numbers);
        await fileService.SaveToFile(numbers, fileService.numbersPath);

        var points = await GeneratePoint(pointsQuantity);
        // pointNoSql = mapper.Map<List<PointNoSql>>(points);
        await fileService.SaveToFile(points, fileService.pointsPath);

        var vectors = await GenerateVector(vectorsQuantity);
        //var vectorsNoSql = mapper.Map<List<VectorNoSql>>(vectors);
        await fileService.SaveToFile(vectors, fileService.vectorsPath);

        var books = await GenerateBook(booksQuantity);
        //var booksNoSql = mapper.Map<List<BookNoSql>>(books);
        await fileService.SaveToFile(books, fileService.booksPath);

        var workers = await GenerateWorker(workersQuantity);
        //var workersNoSql = mapper.Map<List<WorkerNoSql>>(workers);
        await fileService.SaveToFile(workers, fileService.workersPath);

        var libraries = await GenerateLibrary(librariesQuantity);
        //var librariesNoSql = mapper.Map<List<LibraryNoSql>>(libraries);
        await fileService.SaveToFile(libraries, fileService.librariesPath);

        var organizations = await GenerateOrganization(organizationsQuantity);
        //var organisationsNoSql = mapper.Map<List<OrganizationNoSql>>(organisations);
        await fileService.SaveToFile(organizations, fileService.organizationsPath);
        
        var dataSql = new DataHolderSql()
        {
            Books = books,
            Workers = workers,
            Libraries = libraries,
            Organisations = organizations,
            Numbers = numbers,
            Points = points,
            Vectors = vectors,
        };
        
        var dataNoSql = mapper.Map<DataHolderNoSql>(dataSql);

        var data = new DataHolder()
        {
            DataHolderNoSql = dataNoSql,
            DataHolderSql = dataSql
        };

        return data;
    }

    public async Task<DataHolder> PrepareDataFast()
    {
        numberFast = await GenerateNumber(numbersPerPointQuantity);
        //var numberNoSql = mapper.Map<List<NumberNoSql>>(numberFast);
        await fileService.SaveToFile(numberFast, fileService.numbersPath);

        pointFast = await GeneratePointFast(pointsPerVectorQuantity);
        // pointNoSql = mapper.Map<List<PointNoSql>>(pointFast);
        await fileService.SaveToFile(pointFast, fileService.pointsPath);

        var vectors = await GenerateVectorFast(vectorsQuantity);
        //var vectorsNoSql = mapper.Map<List<VectorNoSql>>(vectors);
        await fileService.SaveToFile(vectors, fileService.vectorsPath);

        bookFast = await GenerateBook(booksQuantity);
        //var booksNoSql = mapper.Map<List<BookNoSql>>(bookFast);
        await fileService.SaveToFile(bookFast, fileService.booksPath);

        workerFast = await GenerateWorker(workersQuantity);
        //var workersNoSql = mapper.Map<List<WorkerNoSql>>(workerFast);
        await fileService.SaveToFile(workerFast, fileService.workersPath);

        libraryFast = await GenerateLibraryFast(librariesQuantity);
        //var librariesNoSql = mapper.Map<List<LibraryNoSql>>(libraryFast);
        await fileService.SaveToFile(libraryFast, fileService.librariesPath);

        var organizations = await GenerateOrganizationFast(organizationsQuantity);
        //var organisationsNoSql = mapper.Map<List<OrganizationNoSql>>(organisations);
        await fileService.SaveToFile(organizations, fileService.organizationsPath);
        /*
        var dataSql = new DataHolderSql()
        {
            Books = bookFast,
            Workers = workerFast,
            Libraries = libraryFast,
            Organisations = organizations,
            Numbers = numberFast,
            Points = pointFast,
            Vectors = vectors,
        };

        var dataNoSql = mapper.Map<DataHolderNoSql>(dataSql);

        var data = new DataHolder()
        {
            DataHolderNoSql = dataNoSql,
            DataHolderSql = dataSql
        };

        return data;
        */
        return new DataHolder() { };
    }
    private async Task<List<Book>> GenerateBook(int quantity = 1)
    {
        var books = new List<Book>();
        for (int i = 0; i < quantity; i++)
        {
            var id = await hashIdentifierService.GetHashId();
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
            var id = await hashIdentifierService.GetHashId();
            var number = await NumberGenerator.GetNumber(id);
            numbers.Add(number);
            RefreshProgress(i, quantity, refreshRate);
        }
        //Console.Clear();
        //Console.WriteLine("Completed generating numbers");
        return numbers;
    }
    private async Task<List<Worker>> GenerateWorker(int quantity = 1)
    {
        var workers = new List<Worker>();
        for (int i = 0; i < quantity; i++)
        {
            var id = await hashIdentifierService.GetHashId();
            var worker = await WorkerGenerator.GetWorker(id);
            workers.Add(worker);
            RefreshProgress(i, quantity, refreshRate);
        }
        //Console.Clear();
       // Console.WriteLine("Completed generating workers");
        return workers;
    }
    private async Task<List<Point>> GeneratePoint(int quantity = 1)
    {
        var points = new List<Point>();
        for (int i = 0; i < quantity; i++)
        {
            var id = await hashIdentifierService.GetHashId();
            var point = await PointGenerator.GetPoint(id, GenerateNumber(numbersPerPointQuantity).Result);
            points.Add(point);
            RefreshProgress(i, quantity, refreshRate);
        }
        return points;
    }
    private async Task<List<Point>> GeneratePointFast(int quantity = 1)
    {
        var points = new List<Point>();
        for (int i = 0; i < quantity; i++)
        {
            var id = await hashIdentifierService.GetHashId();
            var point = await PointGenerator.GetPoint(id, numberFast);
            points.Add(point);
            RefreshProgress(i, quantity, refreshRate);
        }
        return points;
    }
    private async Task<List<Vector>> GenerateVector(int quantity = 1)
    {
        var vectors = new List<Vector>();
        for (int i = 0; i < quantity; i++)
        {
            var id = await hashIdentifierService.GetHashId();
            var vector = await VectorGenerator.GetVector(id, GeneratePoint(pointsPerVectorQuantity).Result);
            vectors.Add(vector);
            RefreshProgress(i, quantity, refreshRate);
        }
        return vectors;
    }
    private async Task<List<Vector>> GenerateVectorFast(int quantity = 1)
    {
        var vectors = new List<Vector>();
        for (int i = 0; i < quantity; i++)
        {
            var id = await hashIdentifierService.GetHashId();
            var vector = await VectorGenerator.GetVector(id, pointFast);
            vectors.Add(vector);
            RefreshProgress(i, quantity, refreshRate);
        }
        return vectors;
    }
    private async Task<List<Library>> GenerateLibrary(int quantity = 1)
    {
        var libraries = new List<Library>();
        for (int i = 0; i < quantity; i++)
        {
            var id = await hashIdentifierService.GetHashId();
            var library = 
                await LibraryGenerator.GetLibrary(
                    id,
                    GenerateWorker(workersPerLibraryQuantity).Result,
                    GenerateBook(booksPerLibraryQuantity).Result);
            libraries.Add(library);
            RefreshProgress(i, quantity, refreshRate);
        }
        return libraries;
    }
    private async Task<List<Library>> GenerateLibraryFast(int quantity = 1)
    {
        var libraries = new List<Library>();
        for (int i = 0; i < quantity; i++)
        {
            var id = await hashIdentifierService.GetHashId();
            var library =
                await LibraryGenerator.GetLibrary(
                    id,
                    workerFast,
                    bookFast);
            libraries.Add(library);
            RefreshProgress(i, quantity, refreshRate);
        }
        return libraries;
    }
    private async Task<List<Organization>> GenerateOrganization(int quantity = 1)
    {
        var organizations = new List<Organization>();
        for (int i = 0; i < quantity; i++)
        {
            var id = await hashIdentifierService.GetHashId();
            var library =
                await OrganizationGenerator.GetOrganization(
                    id,
                    GenerateLibrary(librariesPerOrganizationQuantity).Result,
                    GenerateWorker(workersPerOrganizationQuantity).Result);
            organizations.Add(library);
            RefreshProgress(i, quantity, refreshRate);
        }
        //Console.WriteLine("Completed generating organizations");
        return organizations;
    }
    private async Task<List<Organization>> GenerateOrganizationFast(int quantity = 1)
    {
        var organizations = new List<Organization>();
        for (int i = 0; i < quantity; i++)
        {
            var id = await hashIdentifierService.GetHashId();
            var library =
                await OrganizationGenerator.GetOrganization(
                    id,
                    libraryFast,
                    workerFast);
            organizations.Add(library);
            RefreshProgress(i, quantity, refreshRate);
        }
        //Console.WriteLine("Completed generating organizations");
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
