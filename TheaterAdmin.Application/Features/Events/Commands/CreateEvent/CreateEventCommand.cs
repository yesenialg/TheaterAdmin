using MediatR;

namespace TheaterAdmin.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public int ManagerId { get; set; }
    }
}
