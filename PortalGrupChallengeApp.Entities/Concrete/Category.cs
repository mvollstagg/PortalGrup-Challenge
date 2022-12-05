using Microsoft.EntityFrameworkCore;
using PortalGrupChallengeApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace PortalGrupChallengeApp.Entities.Concrete;

public class Category : Entity
{
    [MaxLength(50)]
    public string Name { get; set; }
    public bool Status { get; set; }
    public DateTime CreationDate { get; set; }
}