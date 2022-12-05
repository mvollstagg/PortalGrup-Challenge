using Microsoft.EntityFrameworkCore;
using PortalGrupChallengeApp.Core.Entities;

namespace PortalGrupChallengeApp.Entities.Concrete;

public class OrderItem : Entity
{
    public int SkuId { get; set; }
    public int OrderId { get; set; }
    [Precision(16, 2)]
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public bool Status { get; set; }    
    public DateTime CreationDate { get; set; }
    public virtual SKU Sku { get; set; }
    public virtual Order Order { get; set; }
}