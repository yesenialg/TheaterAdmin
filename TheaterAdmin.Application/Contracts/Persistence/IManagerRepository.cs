using TheaterAdmin.Domain;

namespace TheaterAdmin.Application.Contracts.Persistence
{
    public interface IManagerRepository
    {
        Task<ManagerEntity> CreateManagerAsync(ManagerEntity entity);


        Task<IReadOnlyCollection<ManagerEntity>> GetAllManagersAsync();

        Task<ManagerEntity> GetManagerByIdAsync(int id);

        Task<Task> DeleteManagerAsync(ManagerEntity entity);
    }
}
