﻿using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[ApiController]
public class MongoGenericController<T> : ControllerBase
{
    private readonly GenericNoSqlService<T> _genericService;

    public MongoGenericController(GenericNoSqlService<T> genericService)
    {
        _genericService = genericService;
    }


    [HttpGet]
    public async Task<List<T>> Get() =>
        await _genericService.GetAsync();

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

    [HttpPost]
    public async Task<IActionResult> Post(T newNumber)
    {
        await _genericService.CreateAsync(newNumber);

        return CreatedAtAction(nameof(Get), newNumber);
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

        await _genericService.RemoveAsync(id);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {

        await _genericService.RemoveAllAsync();

        return NoContent();
    }
}