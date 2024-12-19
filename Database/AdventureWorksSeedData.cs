using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiIntegrationTesting.Database;

internal static class AdventureWorksSeedData
{
    internal static void LoadSeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressEntity>().HasData(AddressEntities);
        modelBuilder.Entity<StateProvinceEntity>().HasData(StateProvinceEntities);
        modelBuilder.Entity<SalesTerritoryEntity>().HasData(SalesTerritoryEntities);
        modelBuilder.Entity<CountryRegionEntity>().HasData(CountryRegionEntities);
    }

    private static AddressEntity[] AddressEntities { get; } =
    [
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
    ];
    
    private static StateProvinceEntity[] StateProvinceEntities { get; } =
    [
        new() { StateProvinceId = 1, StateProvinceCode = "WA", CountryRegionCode = "US", IsOnlyStateProvinceFlag = true, Name = "Washington", TerritoryId = 1, Rowguid = Guid.Parse("A1C8400E-2E66-490D-B07D-152FD20A98F4"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { StateProvinceId = 2, StateProvinceCode = "OR", CountryRegionCode = "US", IsOnlyStateProvinceFlag = true, Name = "Oregon", TerritoryId = 2, Rowguid = Guid.Parse("DBEC4896-8168-428B-AB32-3B065D3F44D0"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { StateProvinceId = 3, StateProvinceCode = "CA", CountryRegionCode = "US", IsOnlyStateProvinceFlag = true, Name = "California", TerritoryId = 3, Rowguid = Guid.Parse("62B7E622-2FA3-418C-A0A1-80A4A0FAD0AA"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { StateProvinceId = 4, StateProvinceCode = "NV", CountryRegionCode = "US", IsOnlyStateProvinceFlag = true, Name = "Nevada", TerritoryId = 4, Rowguid = Guid.Parse("6DE84EA7-2F70-4248-82C1-CCD6723B366B"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { StateProvinceId = 5, StateProvinceCode = "AZ", CountryRegionCode = "US", IsOnlyStateProvinceFlag = true, Name = "Arizona", TerritoryId = 5, Rowguid = Guid.Parse("A4C6AA38-754D-4E57-ACA1-E6C48870ECED"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { StateProvinceId = 6, StateProvinceCode = "UT", CountryRegionCode = "US", IsOnlyStateProvinceFlag = true, Name = "Utah", TerritoryId = 6, Rowguid = Guid.Parse("50B62A04-5B67-4F98-97FE-06CECF9F6FA6"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { StateProvinceId = 7, StateProvinceCode = "CO", CountryRegionCode = "US", IsOnlyStateProvinceFlag = true, Name = "Colorado", TerritoryId = 7, Rowguid = Guid.Parse("FF3BCC0D-266C-4E52-986A-0B9A2E173ACA"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { StateProvinceId = 8, StateProvinceCode = "NM", CountryRegionCode = "US", IsOnlyStateProvinceFlag = true, Name = "New Mexico", TerritoryId = 8, Rowguid = Guid.Parse("AA6007F7-D166-4F34-820F-634006614C2D"), ModifiedDate = new DateTime(2024, 12, 19) },
    ];
    
    private static SalesTerritoryEntity[] SalesTerritoryEntities { get; } = 
    [
        new() { TerritoryId = 1, Name = "Northwest", CountryRegionCode = "US", Group = "North America", SalesYtd = 1000000, SalesLastYear = 900000, CostYtd = 500000, CostLastYear = 400000, Rowguid = Guid.Parse("BBF61FC8-BEF4-4CF5-83C8-F333848C2FF3"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { TerritoryId = 2, Name = "Pacific", CountryRegionCode = "US", Group = "North America", SalesYtd = 2000000, SalesLastYear = 1800000, CostYtd = 1000000, CostLastYear = 800000, Rowguid = Guid.Parse("1EC0795F-AB37-48BC-9F94-E3C1C52DDDFA"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { TerritoryId = 3, Name = "West", CountryRegionCode = "US", Group = "North America", SalesYtd = 3000000, SalesLastYear = 2700000, CostYtd = 1500000, CostLastYear = 1200000, Rowguid = Guid.Parse("81203DA3-BEFF-49FC-832E-AE968C25A1F6"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { TerritoryId = 4, Name = "Southwest", CountryRegionCode = "US", Group = "North America", SalesYtd = 4000000, SalesLastYear = 3600000, CostYtd = 2000000, CostLastYear = 1600000, Rowguid = Guid.Parse("15AFB9A6-6344-47E8-A9A2-2C1614450C02"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { TerritoryId = 5, Name = "Central", CountryRegionCode = "US", Group = "North America", SalesYtd = 5000000, SalesLastYear = 4500000, CostYtd = 2500000, CostLastYear = 2000000, Rowguid = Guid.Parse("B663FE21-ED8E-48B3-A2C9-DADD0C3A67C4"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { TerritoryId = 6, Name = "Southeast", CountryRegionCode = "US", Group = "North America", SalesYtd = 6000000, SalesLastYear = 5400000, CostYtd = 3000000, CostLastYear = 2400000, Rowguid = Guid.Parse("87FB2185-3584-467A-B813-94A0349155FF"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { TerritoryId = 7, Name = "Northeast", CountryRegionCode = "US", Group = "North America", SalesYtd = 7000000, SalesLastYear = 6300000, CostYtd = 3500000, CostLastYear = 2800000, Rowguid = Guid.Parse("1ACB9029-0CD4-4934-9342-FA035F12647E"), ModifiedDate = new DateTime(2024, 12, 19) },
        new() { TerritoryId = 8, Name = "Midwest", CountryRegionCode = "US", Group = "North America", SalesYtd = 8000000, SalesLastYear = 7200000, CostYtd = 4000000, CostLastYear = 3200000, Rowguid = Guid.Parse("9E2BF3D1-7D16-451F-BB9D-6D3B7EDDE396"), ModifiedDate = new DateTime(2024, 12, 19) },
    ];
    
    private static CountryRegionEntity[] CountryRegionEntities { get; } = 
    [
        new() { CountryRegionCode = "US", Name = "United States", ModifiedDate = new DateTime(2024, 12, 19) }
    ];}