using DbTesterApp.Controllers.MSSQL;
using DbTesterApp.Models.Sql;
using DbTesterApp.Services;
using DbTesterApp.Services.MSSQL;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.MSSQL;

[Route("api/mssql/[controller]")]
public class MSsqlVectorController : MssqlGenericController<Vector>
{
    public MSsqlVectorController(GenericSqlService<Vector> genericService,
                                HashIdentifierService hashIdentifierService)
        : base(genericService, hashIdentifierService) { }
}