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
}