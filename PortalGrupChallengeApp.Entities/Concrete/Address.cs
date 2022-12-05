using System.ComponentModel.DataAnnotations;
using PortalGrupChallengeApp.Core.Entities;

namespace PortalGrupChallengeApp.Entities.Concrete;

public class Address : Entity
{
    public int CustomerId { get; set; }
    [MaxLength(250)]
    public string AddressLine { get; set; }
    [MaxLength(30)]
    public string Country { get; set; }
    [MaxLength(30)]
    public string City { get; set; }
    [MaxLength(30)]
    public string District { get; set; }
    public int ZipCode { get; set; }
    public bool Status { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual Customer Customer { get; set; }
}