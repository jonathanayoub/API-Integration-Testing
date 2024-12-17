using ApiIntegrationTesting.Database.Entities.Person;
using ApiIntegrationTesting.Database.Entities.Sales;
using ApiIntegrationTesting.Database.Entities.Shield;

namespace ApiIntegrationTesting.Database.Entities;

public class BusinessEntity : BaseEntity
{
    public int BusinessEntityId { get; set; }
    
    public Guid Rowguid { get; set; }
    
    public DateTime ModifiedDate { get; set; }

    public ICollection<PersonEntity> Persons { get; set; }
    
    public ICollection<Vendor> Vendors { get; set; }
    
    public ICollection<StoreEntity> Stores { get; set; }
    
    public ICollection<BusinessEntityAddressEntity> BusinessEntityAddresses { get; set; }
    
    public ICollection<BusinessEntityContactEntity> BusinessEntityContacts { get; set; }

    public ICollection<UserAccountEntity> UserAccounts { get; set; }
    
}