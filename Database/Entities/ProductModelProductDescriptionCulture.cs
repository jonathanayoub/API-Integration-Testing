﻿namespace ApiIntegrationTesting.Database.Entities;

public class ProductModelProductDescriptionCulture : BaseEntity
{
    public int ProductModelId { get; set; }
    
    public int ProductDescriptionId { get; set; }
    
    public string CultureId { get; set; }
    
    public DateTime ModifiedDate { get; set; }

    public virtual ProductDescription ProductDescription { get; set; }
    
    public virtual ProductModel ProductModel { get; set; }
}