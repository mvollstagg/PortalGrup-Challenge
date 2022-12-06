using System.ComponentModel.DataAnnotations;

namespace PortalGrupChallengeApp.API.Models;

public class AddressDTO
{
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
}