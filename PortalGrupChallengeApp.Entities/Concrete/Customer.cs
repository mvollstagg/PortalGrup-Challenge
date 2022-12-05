using System.ComponentModel.DataAnnotations;
using PortalGrupChallengeApp.Core.Entities;

namespace PortalGrupChallengeApp.Entities.Concrete;

public class Customer : Entity
{
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(150)]
    public string Email { get; set; }
    public long TCID { get; set; }
    public DateTime BirthDate { get; set; }
    [MaxLength(20)]
    public string Gsm { get; set; }
    public bool Status { get; set; }
    public DateTime CreationDate { get; set; }
}