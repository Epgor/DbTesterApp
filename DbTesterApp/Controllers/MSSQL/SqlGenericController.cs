using DbTesterApp.Models.Sql;
using DbTesterApp.Services;
using DbTesterApp.Services.MSSQL;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Common;

namespace DbTesterApp.Controllers.MSSQL;

[ApiController]
public class SqlGenericController<T> : ControllerBase where T : class
{
    private readonly GenericSqlService<T> _genericService;
    private readonly HashIdentifierService _hashIdentifierService;

    public SqlGenericController(GenericSqlService<T> genericService, HashIdentifierService hashIdentifierService)
    {
        _genericService = genericService;
        _hashIdentifierService = hashIdentifierService;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] T entity)
    {
        var newEntity = await _hashIdentifierService.SetId(entity, true);
        await _genericService.AddAsync(newEntity);
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

        await _genericService.AddMultipleAsync(newEntities);

        return Created(nameof(Get), newEntities);
    }

    [HttpGet]
    public async Task<ActionResult<List<T>>> GetAll()
    {
        var entities = await _genericService.GetAllAsync();
        if (entities is null || entities.Count == 0)
            return NotFound();
        return Ok(entities);
    }

    [HttpGet("total")]
    public async Task<int> GetTotal()
    {
        var entities = await _genericService.GetAllAsync();

        return entities.Count;
    }


    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<T>> Get([FromRoute] string id)
    {
        var entity = await _genericService.GetAsync(id);
        if (entity is null)
            return NotFound();
        return Ok(entity);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, T updatedEntity)
    {
        var result = await _genericService.UpdateAsync(id, updatedEntity);
        if (result)
            return NoContent();
        return BadRequest(result);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _genericService.DeleteAsync(id);
        if (result)
            return NoContent();
        return BadRequest(result);

    }
    [HttpDelete()]
    public async Task<IActionResult> Delete()
    {
        await _genericService.DeleteAllAsync();

        return NoContent();
    }
}
