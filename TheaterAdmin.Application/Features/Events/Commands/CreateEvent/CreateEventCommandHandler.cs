using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TheaterAdmin.Application.Contracts.Persistence;
using TheaterAdmin.Domain;

namespace TheaterAdmin.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {

        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly ILogger<CreateEventCommandHandler> _logger;

        public CreateEventCommandHandler(IMapper mapper,
                                         IEventRepository eventRepository,
                                         IManagerRepository managerRepository,
                                         ILogger<CreateEventCommandHandler> logger)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _managerRepository = managerRepository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = _mapper.Map<EventEntity>(request);
            eventEntity.Manager = await _managerRepository.GetManagerByIdAsync(request.ManagerId);
            var newEvent = await _eventRepository.CreateEventAsync(eventEntity);

            _logger.LogInformation($"Event {newEvent.Id}: {newEvent.Name} created");

            return newEvent.Id;
        }
    }
}
