using DbTesterApp.Controllers.MSSQL;
using DbTesterApp.Models.Sql;
using DbTesterApp.Services.MSSQL;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mssql/[controller]")]
public class SqlLibraryController : SqlGenericController<Library>
{
    public SqlLibraryController(GenericSqlService<Library> genericService)
        : base(genericService) {}
}