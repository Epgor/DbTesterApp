using DbTesterApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookGenerationController : ControllerBase
{
    private readonly DataPreparationService dataService;
    private readonly JsonFileService fileService;
    public BookGenerationController(DataPreparationService dataService, JsonFileService fileService)
    {
        this.dataService = dataService;
        this.fileService = fileService;
    }

    [HttpGet("{quantity}")]
    public async Task<ActionResult> GenerateData([FromRoute]int quantity, [FromQuery]int refreshRate = 10)
    {
        await dataService.PrepareData();
        //var writingResult = await fileService.SaveToFile(books, fileService.booksPath);
        return Ok($"Generated {quantity} books; Writing to file status ");
    }
}
