using TheaterAdmin.Domain;

namespace TheaterAdmin.Application.Contracts.Persistence
{
    public interface IEventRepository
    {
        Task<EventEntity> CreateEventAsync(EventEntity entity);

        Task<IReadOnlyCollection<EventEntity>> GetEventsByManagerIdAsync(int id);

        Task<IReadOnlyCollection<EventEntity>> GetAllEventsAsync();

        Task<EventEntity> GetEventByIdAsync(int id);

        Task<Task> DeleteEventAsync(EventEntity entity);
            
    }
}
