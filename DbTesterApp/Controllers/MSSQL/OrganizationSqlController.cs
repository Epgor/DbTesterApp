using DbTesterApp.Controllers.MSSQL;
using DbTesterApp.Models.Sql;
using DbTesterApp.Services;
using DbTesterApp.Services.MSSQL;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.MSSQL;

[Route("api/mssql/[controller]")]
public class MSsqlOrganizationController : MssqlGenericController<Organization>
{
    private readonly GenericSqlService<Organization> _genericService;
    private readonly HashIdentifierService _hashIdentifierService;
    public MSsqlOrganizationController(GenericSqlService<Organization> genericService,
                                HashIdentifierService hashIdentifierService)
        : base(genericService, hashIdentifierService) 
    { 
        _genericService = genericService;
        _hashIdentifierService = hashIdentifierService;
    }

    [HttpPost("org")]
    public async Task<ActionResult> PostOrganization([FromBody] Organization entity)
    {
        entity.Id = await _hashIdentifierService.GetFastHashId();
        foreach(var worker in entity.Workers)
            worker.Id = await _hashIdentifierService.GetFastHashId();

        foreach(var lib in entity.Libraries)
        {
            foreach(var worker in lib.Workers)
                worker.Id = await _hashIdentifierService.GetFastHashId();

            foreach (var book in lib.Books)
                book.Id = await _hashIdentifierService.GetFastHashId();
        }

        await _genericService.AddAsync(entity);
        return Created(nameof(Get), entity);
    }

    [HttpPost("org/full")]
    public async Task<ActionResult> PostOrganizationFull([FromBody] Organization entity)
    {

        foreach (var worker in entity.Workers)
            worker.Id = await _hashIdentifierService.GetFastHashId();

        foreach (var lib in entity.Libraries)
        {
            foreach (var worker in lib.Workers)
                worker.Id = await _hashIdentifierService.GetFastHashId();

            foreach (var book in lib.Books)
                book.Id = await _hashIdentifierService.GetFastHashId();
        }

        await _genericService.AddAsync(entity);
        return Created(nameof(Get), entity);
    }


    [HttpPut("org")]
    public async Task<ActionResult> UpdateOrganization([FromBody] Organization entity)
    {
        await _genericService.UpdateAddressAsync(entity.Id, entity.Address);
        await _hashIdentifierService.GetHashId();
        return Ok();
    }
}