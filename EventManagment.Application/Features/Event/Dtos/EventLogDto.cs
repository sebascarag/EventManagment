using EventMangment.Domain.Enums;

namespace EventManagment.Application.Features.Event.Dtos
{
    public class EventLogDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public EEventType EType { get; set; }
        public string ETypeText { get => EType.ToString(); }
    }
}
