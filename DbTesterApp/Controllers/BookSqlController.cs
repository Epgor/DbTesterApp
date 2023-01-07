using DbTesterApp.Models;
using DbTesterApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookSqlController : ControllerBase
{


    private readonly BookSqlService _bookSqlService;

    public BookSqlController(BookSqlService bookSqlService) =>
        _bookSqlService = bookSqlService;

    [HttpGet]
    public ActionResult<List<Book>> GetAll()
    {
        var books = _bookSqlService.GetAll();
        return Ok(books);
    }
    [HttpGet("{name}")]
    public ActionResult<Book> GetBookSql([FromRoute]string name)
    {
        var book = _bookSqlService.GetTestBook(name);
        return Ok(book);
    }

    [HttpPost]
    public ActionResult PostBookSql([FromBody] string name)
    {
        _bookSqlService.AddTestBook(name);
        return Ok();

    }
}
