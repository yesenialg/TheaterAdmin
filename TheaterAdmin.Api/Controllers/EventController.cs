using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TheaterAdmin.Application.Features.Events.Commands.CreateEvent;
using TheaterAdmin.Application.Features.Events.Queries.GetEventsList;
using TheaterAdmin.Domain;

namespace TheaterAdmin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {

        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateEvent")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateEvent([FromBody] CreateEventCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IReadOnlyCollection<EventEntity>> GetAllEvents()
        {
            var command = new GetEventsListQuery();
            return await _mediator.Send(command);
        }
    }
}