using DbTesterApp.DTO;
using DbTesterApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenerationController : ControllerBase
{
    private readonly DataPreparationService dataService;
    private readonly JsonFileService fileService;
    private readonly HashIdentifierService hashIdentifierService;
    public GenerationController(DataPreparationService dataService, JsonFileService fileService, HashIdentifierService hashIdentifierService)
    {
        this.dataService = dataService;
        this.fileService = fileService;
        this.hashIdentifierService = hashIdentifierService;
    }

    [HttpGet("regular")]
    public async Task<ActionResult<DataHolderSql>> GenerateData()
    {
        var some = 100;
        dataService.Configure(
            some,
            some,
            some,
            some,
            some,
            some,
            some,
            some,
            some,
            some,
            some,
            some);
        var result = await dataService.PrepareData();
        //var writingResult = await fileService.SaveToFile(books, fileService.booksPath);
        return Ok(result);
    }

    [HttpGet("fast")]
    public async Task<ActionResult<DataHolderSql>> GenerateDataFast()
    {
        var some = 100;
        dataService.Configure(
            some,
            some,
            some,
            some,
            some,
            some,
            some,
            some,
            some,
            some,
            some,
            some);
        var result = await dataService.PrepareDataFast();
        //var writingResult = await fileService.SaveToFile(books, fileService.booksPath);
        return Ok(result);
    }

    [HttpGet("id")]
    public async Task<List<string>> GenerateNumber(int quantity)
    {
        var values = new List<string>();
        for(int i = 0; i < quantity; i++)
        {
            var number = hashIdentifierService.GetHashId();
            values.Add(number);
            if (i % 100 == 0)
            {
                var division = (double)i / quantity;
                var value = Math.Round((division * 100), 3);
                Console.WriteLine($"{value}%");
            }
                
        }
        return values;
    }
}
