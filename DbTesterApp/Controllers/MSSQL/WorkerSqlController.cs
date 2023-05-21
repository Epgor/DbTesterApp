using DbTesterApp.Controllers.MSSQL;
using DbTesterApp.Models.Sql;
using DbTesterApp.Services;
using DbTesterApp.Services.MSSQL;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.MSSQL;

[Route("api/mssql/[controller]")]
public class MSsqlWorkerController : MssqlGenericController<Worker>
{
    public MSsqlWorkerController(GenericSqlService<Worker> genericService,
                                HashIdentifierService hashIdentifierService)
        : base(genericService, hashIdentifierService) { }
}