using TheaterAdmin.Infrastructure.Persistence.Common;

namespace TheaterAdmin.Infrastructure.Persistence
{
    public class Event : BaseInfraestructureEntity
    {
        public Event()
        {
            Schedules = new HashSet<Schedule>();
        }

        public string? Name { get; set; }

        public int? ManagerId { get; set; }

        public virtual Manager? Manager { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
