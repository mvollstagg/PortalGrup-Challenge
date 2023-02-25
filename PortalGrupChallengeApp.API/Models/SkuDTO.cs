using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.API.Models;

public class SkuDTO
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
}