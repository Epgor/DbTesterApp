using DbTesterApp.Controllers.MSSQL;
using DbTesterApp.Models.Sql;
using DbTesterApp.Services;
using DbTesterApp.Services.MSSQL;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.MSSQL;

[Route("api/mssql/[controller]")]
public class MSsqlNumberController : MssqlGenericController<Number>
{
    public MSsqlNumberController(GenericSqlService<Number> genericService,
                                HashIdentifierService hashIdentifierService)
        : base(genericService, hashIdentifierService) { }
}