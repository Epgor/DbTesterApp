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
        var some = 3;
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
        var some = 3;
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
    public async Task<string> GenerateNextId()
    {
        return await hashIdentifierService.GetHashId();
    }
    [HttpGet("fastId")]
    public async Task<string> GenerateFastNextId()
    {
        return await hashIdentifierService.GetFastHashId();
    }
}
