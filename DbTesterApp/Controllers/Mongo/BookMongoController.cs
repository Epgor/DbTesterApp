using DbTesterApp.Models;
using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[ApiController]
[Route("api/mongo/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BooksNoSqlService _booksService;

    public BooksController(BooksNoSqlService booksService) =>
        _booksService = booksService;

    [HttpGet]
    public async Task<List<BookNoSql>> Get() =>
        await _booksService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<BookNoSql>> Get(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(BookNoSql newBook)
    {
        await _booksService.CreateAsync(newBook);

        return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, BookNoSql updatedBook)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _booksService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _booksService.RemoveAsync(id);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {

        await _booksService.RemoveAllAsync();

        return NoContent();
    }
}