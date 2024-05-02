using AutoMapper;
using TheaterAdmin.Application.Contracts.Persistence;
using TheaterAdmin.Domain;
using TheaterAdmin.Infrastructure.Persistence;

namespace TheaterAdmin.Infrastructure.Repositories
{
    public class ScheduleRepository : RepositoryBase<Event, EventEntity>, IScheduleRepository
    {
        public ScheduleRepository(TheaterDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
