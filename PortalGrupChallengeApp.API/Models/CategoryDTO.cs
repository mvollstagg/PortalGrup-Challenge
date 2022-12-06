using System.ComponentModel.DataAnnotations;

namespace PortalGrupChallengeApp.API.Models;

public class CategoryDTO
{
    [MaxLength(50)]
    public string Name { get; set; }
    public bool Status { get; set; }
    public DateTime CreationDate { get; set; }
}