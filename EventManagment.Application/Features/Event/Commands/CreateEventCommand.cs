using EventManagment.Application.Contracts;
using EventManagment.Application.Exceptions;
using EventMangment.Domain.Entities;
using EventMangment.Domain.Enums;
using FluentValidation;
using MediatR;

namespace EventManagment.Application.Features.Event.Commands
{
    public record CreateEventCommandRequest : IRequest<bool>
    {
        public DateTime Date { get; init; }
        public string? Description { get; init; }
        public EEventType EType { get; init; }
    }

    public class CreateEventCommandValidation : AbstractValidator<CreateEventCommandRequest>
    {
        public CreateEventCommandValidation()
        {
            RuleFor(x => x.Date)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.EType)
                .IsInEnum();
        }
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommandRequest, bool>
    {
        private readonly IRepository<EventLog> _eventRepo;

        public CreateEventCommandHandler(IRepository<EventLog> eventRepo)
        {
            _eventRepo = eventRepo;
        }
        public async Task<bool> Handle(CreateEventCommandRequest request, CancellationToken cancellationToken)
        {
            var eventLog = new EventLog()
            {
                Date = request.Date,
                Description = request.Description!,
                EType = request.EType,
                Active = true
            };
            _eventRepo.Add(eventLog);
            var result = await _eventRepo.SaveAsync(cancellationToken);
            if (result)
                return result;
            else
                throw new ApiException("EventLog could not be save");
        }
    }
}
