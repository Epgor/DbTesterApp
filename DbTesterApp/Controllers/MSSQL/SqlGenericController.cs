using DbTesterApp.Models.Sql;
using DbTesterApp.Services.MSSQL;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Common;

namespace DbTesterApp.Controllers.MSSQL;

[ApiController]
public class SqlGenericController<T> : ControllerBase where T : class
{
    private readonly GenericSqlService<T> _genericSqlService;

    public SqlGenericController(GenericSqlService<T> genericSqlService) =>
        _genericSqlService = genericSqlService;

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] T entity)
    {
        await _genericSqlService.AddAsync(entity);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<T>>> GetAll()
    {
        var entities = await _genericSqlService.GetAllAsync();
        if (entities is null || entities.Count == 0)
            return NotFound();
        return Ok(entities);
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<T>> Get([FromRoute] string id)
    {
        var entity = await _genericSqlService.GetAsync(id);
        if (entity is null)
            return NotFound();
        return Ok(entity);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, T updatedEntity)
    {
        var result = await _genericSqlService.UpdateAsync(id, updatedEntity);
        if (result)
            return NoContent();
        return BadRequest(result);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _genericSqlService.DeleteAsync(id);
        if (result)
            return NoContent();
        return BadRequest(result);

    }
    [HttpDelete()]
    public async Task<IActionResult> Delete()
    {
        await _genericSqlService.DeleteAllAsync();

        return NoContent();
    }
}
