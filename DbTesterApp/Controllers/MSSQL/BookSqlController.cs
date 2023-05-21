using DbTesterApp.Controllers.MSSQL;
using DbTesterApp.Models.Sql;
using DbTesterApp.Services;
using DbTesterApp.Services.MSSQL;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.MSSQL;

[Route("api/mssql/[controller]")]
public class MSsqlBookController : MssqlGenericController<Book>
{
    public MSsqlBookController(GenericSqlService<Book> genericService,
                                HashIdentifierService hashIdentifierService)
        : base(genericService, hashIdentifierService) { }
}