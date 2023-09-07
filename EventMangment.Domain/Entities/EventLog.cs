using EventMangment.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EventMangment.Domain.Entities;

public class EventLog : BaseEntity
{
    [Required]
    public DateTime Date { get; set; }
    [Required]
    [StringLength(100)]
    public string? Description { get; set; }
    [Required]
    public EEventType EType { get; set; }
}
