using ApiIntegrationTesting.Database.Entities.Person;

namespace ApiIntegrationTesting.Database.Entities;

public class PersonCreditCard : BaseEntity
{
    public int BusinessEntityId { get; set; }

    public int CreditCardId { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual PersonEntity BusinessEntity { get; set; }

    public virtual CreditCard CreditCard { get; set; }

}