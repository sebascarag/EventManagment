using EventManagment.Api.Extensions;
using EventManagment.Application.Features.Event.Commands;
using EventManagment.Application.Features.Event.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventManagment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventLogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventLogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEventCommandRequest request)
        {
            return this.OkResponse(await _mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetEventQueryRequest request)
        {
            return this.OkResponse(await _mediator.Send(request));
        }
    }
}
