using System.ComponentModel.DataAnnotations;

namespace PortalGrupChallengeApp.API.Models;

public class CustomerDTO
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
    public AddressDTO Address { get; set; }
}