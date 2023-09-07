using AutoMapper;
using EventManagment.Application.Contracts;
using EventManagment.Application.Extensions;
using EventManagment.Application.Features.Event.Dtos;
using EventMangment.Domain.Entities;
using EventMangment.Domain.Enums;
using FluentValidation;
using MediatR;

namespace EventManagment.Application.Features.Event.Queries
{
    public record GetEventQueryRequest : IRequest<IList<EventLogDto>>
    {
        public EEventType? EType { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }

    public class GetEventQueryValidation : AbstractValidator<GetEventQueryRequest> 
    {
        public GetEventQueryValidation()
        {
            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate)
                .When(x => x.EndDate.HasValue);
            RuleFor(x => x.EType)
                .IsInEnum()
                .When(x => x.EType.HasValue);
        }
    }

    public class GetEventQueryHandler : IRequestHandler<GetEventQueryRequest, IList<EventLogDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EventLog> _eventRepo;
        public GetEventQueryHandler(IRepository<EventLog> eventRepo, IMapper mapper)
        {
            _mapper = mapper;
            _eventRepo = eventRepo;
        }
        public async Task<IList<EventLogDto>> Handle(GetEventQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _eventRepo.GetAllActive()
                            .WhereIf(x => x.EType == request.EType, request.EType.HasValue)
                            .WhereIf(x => x.Date >= request.StartDate!.Value.StartOfDay(), request.StartDate.HasValue)
                            .WhereIf(x => x.Date <= request.EndDate!.Value.EndOfDay(), request.EndDate.HasValue)
                            .OrderBy(x => x.Date);
            var eventLogList = await _eventRepo.ToListAsync(query, cancellationToken);
            return _mapper.Map<IList<EventLogDto>>(eventLogList);
        }
    }
}
