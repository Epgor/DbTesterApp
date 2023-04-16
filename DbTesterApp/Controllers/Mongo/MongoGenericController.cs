using DbTesterApp.Services;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Common;

namespace DbTesterApp.Controllers.Mongo;

[ApiController]
public class MongoGenericController<T> : ControllerBase
{
    private readonly GenericMongoService<T> _genericService;
    private readonly HashIdentifierService _hashIdentifierService;

    public MongoGenericController(GenericMongoService<T> genericService, HashIdentifierService hashIdentifierService)
    {
        _genericService = genericService;
        _hashIdentifierService = hashIdentifierService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] T entity)
    {
        var newEntity = await _hashIdentifierService.SetId(entity, true);
        await _genericService.CreateAsync(newEntity);

        return Created(nameof(Get), newEntity);
    }

    [HttpPost("many")]
    public async Task<ActionResult> Post([FromBody] IEnumerable<T> entities)
    {
        var newEntities = new List<T>();

        foreach (var entity in entities)
        {
            var newEntity = await _hashIdentifierService.SetId(entity, true);
            newEntities.Add(newEntity);
        }

        await _genericService.CreateManyAsync(newEntities);

        return Created(nameof(Get), newEntities);
    }

    [HttpGet("total")]
    public async Task<ActionResult> total() 
    {
        var list = await _genericService.GetAsync();
        var total = list.Count;
        return Ok(total);
    }

    [HttpGet]
    public async Task<List<T>> GetAll()
    {
        return await _genericService.GetAsync();
    }  

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<T>> Get(string id)
    {
        var book = await _genericService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, T updatedNumber)
    {
        var book = await _genericService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _genericService.UpdateAsync(id, updatedNumber);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _genericService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _genericService.DeleteAsync(id);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {

        await _genericService.DeleteAllAsync();

        return NoContent();
    }
}