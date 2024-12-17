namespace ApiIntegrationTesting.Database.Entities;

public class ScrapReason : BaseEntity
{

    public short ScrapReasonId { get; set; }
    public string Name { get; set; }
    public DateTime ModifiedDate { get; set; }

    public ICollection<WorkOrder> WorkOrders { get; set; }
}