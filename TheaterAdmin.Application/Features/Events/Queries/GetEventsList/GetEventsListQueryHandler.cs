using MediatR;
using TheaterAdmin.Application.Contracts.Persistence;
using TheaterAdmin.Domain;

namespace TheaterAdmin.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, IReadOnlyCollection<EventEntity>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IManagerRepository _managerRepository;

        public GetEventsListQueryHandler(IEventRepository eventRepository, IManagerRepository managerRepository)
        {
            _eventRepository = eventRepository;
            _managerRepository = managerRepository;
        } 

        public async Task<IReadOnlyCollection<EventEntity>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.GetAllEventsAsync();

            foreach (var eve in events)
            {
                if (eve.Manager != null)
                {
                    eve.Manager = await _managerRepository.GetManagerByIdAsync(eve.Manager.Id);
                }
            }

            return events;
        }
    }
}
