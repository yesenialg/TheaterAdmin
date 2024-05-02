using MediatR;
using TheaterAdmin.Domain;

namespace TheaterAdmin.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<IReadOnlyCollection<EventEntity>>
    {
    }
}
