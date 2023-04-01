using DbTesterApp.Controllers.MSSQL;
using DbTesterApp.Models.Sql;
using DbTesterApp.Services.MSSQL;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mssql/[controller]")]
public class SqlPointController : SqlGenericController<Point>
{
    public SqlPointController(GenericSqlService<Point> genericService)
        : base(genericService) {}
}