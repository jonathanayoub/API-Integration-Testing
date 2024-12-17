namespace ApiIntegrationTesting.Database.Entities.Person;

public sealed class ContactTypeEntity : BaseEntity
{
    public int ContactTypeId { get; set; }

    public string Name { get; set; }

    public DateTime ModifiedDate { get; set; }

    public ICollection<BusinessEntityContactEntity> BusinessEntityContacts { get; set; }

}