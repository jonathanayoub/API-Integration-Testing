using System.Text;
using System.Text.Json;
using System.Transactions;
using ApiIntegrationTesting.Database;
using ApiIntegrationTesting.Database.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace ApiIntegrationTesting.Tests.Controllers;

[TestClass]
public class AddressControllerTests
{
    private readonly HttpClient _httpClient;

    public AddressControllerTests()
    {
        var factory = new CustomWebApplicationFactory();
        _httpClient = factory.CreateDefaultClient();
    }
    
    [TestMethod]
    public async Task GivenUpdatedAddressData_PutAddresses_UpdatesAddressesAsExpected()
    {
        var updatedAddresses = new List<AddressEntity>
        {
            new() { AddressId = 1, AddressLine1 = "Main Street Change", AddressLine2 = "Apt change", City = "Seattle", StateProvinceId = 1, PostalCode = "98101", Rowguid = Guid.Parse("665356E2-4C0F-4242-8FAE-E3233BFC2AA2"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 2, AddressLine1 = "456 Elm St change", AddressLine2 = "Apt 2", City = "Portland change", StateProvinceId = 3, PostalCode = "97201", Rowguid = Guid.Parse("FE8F357A-2BD0-4B56-A62A-895C8C5F9860"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 3, AddressLine1 = "789 Oak St change", AddressLine2 = "Apt 3", City = "San Francisco change", StateProvinceId = 3, PostalCode = "94101 change", Rowguid = Guid.Parse("9362627A-A733-423E-A48D-8AA22633B0A4"), ModifiedDate = new DateTime(2024, 12, 19) },
        };
        string json = JsonSerializer.Serialize(updatedAddresses);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await _httpClient.PutAsync("api/addresses", content);
        
        response.EnsureSuccessStatusCode();
        
        AdventureWorksDbContext dbContext = await TestDatabaseFixture.CreateContext();
        List<AddressEntity> updatedAddressesResult = dbContext.Addresses.Where(a => a.AddressId == 1 || a.AddressId == 2 || a.AddressId == 3).ToList();
        updatedAddressesResult.Should().BeEquivalentTo(updatedAddresses);
    }
    
    [TestMethod]
    public async Task GetAddresses_ReturnsExpectedAddresses()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/addresses");
        response.EnsureSuccessStatusCode();
        string responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<AddressEntity>>(
            responseString, 
            options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        
        var expectedResult = new List<AddressEntity>
        {
            new() { AddressId = 1, AddressLine1 = "123 Main St", AddressLine2 = "Apt 1", City = "Seattle", StateProvinceId = 1, PostalCode = "98101", Rowguid = Guid.Parse("665356E2-4C0F-4242-8FAE-E3233BFC2AA2"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 2, AddressLine1 = "456 Elm St", AddressLine2 = "Apt 2", City = "Portland", StateProvinceId = 2, PostalCode = "97201", Rowguid = Guid.Parse("FE8F357A-2BD0-4B56-A62A-895C8C5F9860"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 3, AddressLine1 = "789 Oak St", AddressLine2 = "Apt 3", City = "San Francisco", StateProvinceId = 3, PostalCode = "94101", Rowguid = Guid.Parse("9362627A-A733-423E-A48D-8AA22633B0A4"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 4, AddressLine1 = "101 Pine St", AddressLine2 = "Apt 4", City = "Los Angeles", StateProvinceId = 3, PostalCode = "90001", Rowguid = Guid.Parse("8A20E5E0-BB0C-4C73-9E40-07A777C49008"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 5, AddressLine1 = "202 Maple St", AddressLine2 = "Apt 5", City = "San Diego", StateProvinceId = 3, PostalCode = "92101", Rowguid = Guid.Parse("84F1C56E-6489-4BCD-B9A4-EFF75FDE1724"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 6, AddressLine1 = "303 Birch St", AddressLine2 = "Apt 6", City = "Las Vegas", StateProvinceId = 4, PostalCode = "89101", Rowguid = Guid.Parse("0534AD60-4B52-4C6B-A5D3-548C82FE174D"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 7, AddressLine1 = "404 Cedar St", AddressLine2 = "Apt 7", City = "Phoenix", StateProvinceId = 5, PostalCode = "85001", Rowguid = Guid.Parse("DC27C157-C1E7-4D53-9B27-D5E99FE53447"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 8, AddressLine1 = "505 Walnut St", AddressLine2 = "Apt 8", City = "Denver", StateProvinceId = 6, PostalCode = "80201", Rowguid = Guid.Parse("FCFB48A7-BEFF-42CC-90BF-A6483590789F"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 9, AddressLine1 = "606 Chestnut St", AddressLine2 = "Apt 9", City = "Salt Lake City", StateProvinceId = 7, PostalCode = "84101", Rowguid = Guid.Parse("914A3DA5-EA83-43FC-963C-C1C40E8291EA"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 10, AddressLine1 = "707 Spruce St", AddressLine2 = "Apt 10", City = "Albuquerque", StateProvinceId = 8, PostalCode = "87101", Rowguid = Guid.Parse("6F9880F9-6E89-4FD9-B88B-3131970863C5"), ModifiedDate = new DateTime(2024, 12, 19) }
        };
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [TestMethod]
    public async Task GivenUpdatedAddressData_PutAddresses_ReturnsUpdatedAddresses()
    {
        var updatedAddresses = new List<AddressEntity>
        {
            new() { AddressId = 1, AddressLine1 = "Main Street Change", AddressLine2 = "Apt change", City = "Seattle", StateProvinceId = 1, PostalCode = "98101", Rowguid = Guid.Parse("665356E2-4C0F-4242-8FAE-E3233BFC2AA2"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 2, AddressLine1 = "456 Elm St change", AddressLine2 = "Apt 2", City = "Portland change", StateProvinceId = 3, PostalCode = "97201", Rowguid = Guid.Parse("FE8F357A-2BD0-4B56-A62A-895C8C5F9860"), ModifiedDate = new DateTime(2024, 12, 19) },
            new() { AddressId = 3, AddressLine1 = "789 Oak St change", AddressLine2 = "Apt 3", City = "San Francisco change", StateProvinceId = 3, PostalCode = "94101 change", Rowguid = Guid.Parse("9362627A-A733-423E-A48D-8AA22633B0A4"), ModifiedDate = new DateTime(2024, 12, 19) },
        };
        string json = JsonSerializer.Serialize(updatedAddresses);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await _httpClient.PutAsync("api/addresses", content);
        
        response.EnsureSuccessStatusCode();
        
        string responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<AddressEntity>>(
            responseString, 
            options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        result.Should().BeEquivalentTo(updatedAddresses);
    }
}