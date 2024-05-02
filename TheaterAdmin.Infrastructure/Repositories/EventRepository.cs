using AutoMapper;
using TheaterAdmin.Application.Contracts.Persistence;
using TheaterAdmin.Domain;
using TheaterAdmin.Infrastructure.Persistence;

namespace TheaterAdmin.Infrastructure.Repositories
{
    public class EventRepository : RepositoryBase<Event, EventEntity>, IEventRepository
    {
        public EventRepository(TheaterDbContext context, IMapper mapper) : base(context, mapper) 
        { 
        }

        public async Task<EventEntity> CreateEventAsync(EventEntity entity)
        {
            return await AddAsync(entity);       
        }

        public async Task<IReadOnlyCollection<EventEntity>> GetEventsByManagerIdAsync(int id)
        {
            return await GetAsync(_ => _.ManagerId == id);
        }

        public async Task<IReadOnlyCollection<EventEntity>> GetAllEventsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<EventEntity> GetEventByIdAsync(int id) 
        {
            return await GetByIdAsync(id);
        }

        public async Task<Task> DeleteEventAsync(EventEntity entity)
        {
            await DeleteAsync(entity);
            return Task.CompletedTask;
        }
    }
}
 