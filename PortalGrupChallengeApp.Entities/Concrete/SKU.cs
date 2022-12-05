using System.ComponentModel.DataAnnotations;
using PortalGrupChallengeApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace PortalGrupChallengeApp.Entities.Concrete;

public class SKU : Entity
{
    public int CategoryId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(250)]
    public string Description { get; set; }
    [Precision(16, 2)]
    public decimal OldPrice { get; set; }
    [Precision(16, 2)]
    public decimal Price { get; set; }
    public bool Status { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual Category Category { get; set; }
}