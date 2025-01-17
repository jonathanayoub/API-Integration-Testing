﻿namespace ApiIntegrationTesting.Database.Entities;

public class ProductCostHistory : BaseEntity
{
    public int ProductId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal StandardCost { get; set; }
    public DateTime ModifiedDate { get; set; }

    public virtual Product Product { get; set; }
}