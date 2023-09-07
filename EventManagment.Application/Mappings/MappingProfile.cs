using AutoMapper;
using EventManagment.Application.Features.Event.Dtos;
using EventMangment.Domain.Entities;

namespace EventManagment.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EventLog, EventLogDto>();
        }
    }
}
