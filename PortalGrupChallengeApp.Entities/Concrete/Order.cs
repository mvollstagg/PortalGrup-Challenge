using Microsoft.EntityFrameworkCore;
using PortalGrupChallengeApp.Core.Entities;

namespace PortalGrupChallengeApp.Entities.Concrete;

public class Order : Entity
{
    public int CustomerId { get; set; }
    public int AddressId { get; set; }
    [Precision(16, 2)]
    public decimal TotalPrice { get; set; }
    public bool Status { get; set; }    
    public DateTime CreationDate { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Address Address { get; set; }
}