﻿using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mongo/[controller]")]
public class MongoPointController : MongoGenericController<PointNoSql>
{
    public MongoPointController(GenericMongoService<PointNoSql> genericService)
        : base(genericService) {}
}