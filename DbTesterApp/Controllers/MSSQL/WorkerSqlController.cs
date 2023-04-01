using DbTesterApp.Controllers.MSSQL;
using DbTesterApp.Models.Sql;
using DbTesterApp.Services.MSSQL;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mssql/[controller]")]
public class SqlWorkerController : SqlGenericController<Worker>
{
    public SqlWorkerController(GenericSqlService<Worker> genericService)
        : base(genericService) {}
}