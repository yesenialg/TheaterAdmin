using AutoMapper;
using TheaterAdmin.Application.Contracts.Persistence;
using TheaterAdmin.Domain;
using TheaterAdmin.Infrastructure.Persistence;

namespace TheaterAdmin.Infrastructure.Repositories
{
    public class ManagerRepository : RepositoryBase<Manager, ManagerEntity>, IManagerRepository
    {
        public ManagerRepository(TheaterDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ManagerEntity> CreateManagerAsync(ManagerEntity entity)
        {
            return await AddAsync(entity);
        }

        public async Task<IReadOnlyCollection<ManagerEntity>> GetAllManagersAsync()
        {
            return await GetAllAsync();
        }

        public async Task<ManagerEntity> GetManagerByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<Task> DeleteManagerAsync(ManagerEntity entity)
        {
            await DeleteAsync(entity);
            return Task.CompletedTask;
        }
    }
}
