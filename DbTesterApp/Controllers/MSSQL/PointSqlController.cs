﻿using DbTesterApp.Controllers.MSSQL;
using DbTesterApp.Models.Sql;
using DbTesterApp.Services;
using DbTesterApp.Services.MSSQL;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mssql/[controller]")]
public class MSsqlPointController : MssqlGenericController<Point>
{
    public MSsqlPointController(GenericSqlService<Point> genericService,
                                HashIdentifierService hashIdentifierService)
        : base(genericService, hashIdentifierService) { }
}