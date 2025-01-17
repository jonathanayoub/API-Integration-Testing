﻿using ApiIntegrationTesting.Database.Entities.Person;

namespace ApiIntegrationTesting.Database.Entities.Shield;

public sealed class UserAccountEntity : BaseEntity
{
    public int BusinessEntityId { get; set; }

    public Guid RecordId { get; set; }

    public DateTime ModifiedDate { get; set; }

    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public int PrimaryEmailAddressId { get; set; }

    public BusinessEntity BusinessEntity { get; set; }

    public PersonEntity Person { get; set; }

    public EmailAddress EmailAddress { get; set; }

    public ICollection<SecurityGroupUserAccountEntity> SecurityGroupUserAccountEntities { get; set; }

    public ICollection<UserRefreshTokenEntity> UserRefreshTokenEntities { get; set; }
}
