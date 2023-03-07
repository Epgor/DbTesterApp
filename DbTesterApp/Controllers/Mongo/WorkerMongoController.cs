using DbTesterApp.Models;
using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[ApiController]
[Route("api/mongo/[controller]")]
public class WorkersController : ControllerBase
{
    private readonly WorkersNoSqlService _workersService;

    public WorkersController(WorkersNoSqlService workersService) =>
        _workersService = workersService;

    [HttpGet]
    public async Task<List<WorkerNoSql>> Get() =>
        await _workersService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<WorkerNoSql>> Get(string id)
    {
        var book = await _workersService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(WorkerNoSql newWorker)
    {
        await _workersService.CreateAsync(newWorker);

        return CreatedAtAction(nameof(Get), new { id = newWorker.Id }, newWorker);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, WorkerNoSql updatedWorker)
    {
        var book = await _workersService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedWorker.Id = book.Id;

        await _workersService.UpdateAsync(id, updatedWorker);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _workersService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _workersService.RemoveAsync(id);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {

        await _workersService.RemoveAllAsync();

        return NoContent();
    }
}