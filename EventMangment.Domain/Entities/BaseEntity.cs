using System.ComponentModel.DataAnnotations;

namespace EventMangment.Domain.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public bool Active { get; set; } = true;
    [Required]
    [StringLength(150)]
    public string? CreatedBy { get; set; }
    [Required]
    public DateTime CreatedOn { get; set; }
    [StringLength(150)]
    public string? ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
}