using ApiIntegrationTesting.Database;
using ApiIntegrationTesting.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiIntegrationTesting.Controllers;

[ApiController]
[Route("api/addresses")]
public class AddressesController(AdventureWorksDbContext dbContext) : ControllerBase
{
    private readonly AdventureWorksDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddressEntity>>> GetAddresses()
    {
        return await _dbContext.Addresses.ToListAsync();
    }
    
    [HttpPut]
    public async Task<ActionResult<List<AddressEntity>>> UpdateAddress(List<AddressEntity> addresses)
    {
        var updatedAddresses = new List<AddressEntity>
        {
            new() { AddressId = 1, AddressLine1 = "Main Street Change", AddressLine2 = "Apt change", City = "Seattle", StateProvinceId = 1, PostalCode = "98101", Rowguid = Guid.Parse("665356E2-4C0F-4242-8FAE-E3233BFC2AA2"), ModifiedDate = new DateTime(2024, 12, 19) },
        };
        return Ok(updatedAddresses);
    }
}