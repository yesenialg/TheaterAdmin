using TheaterAdmin.Infrastructure.Persistence.Common;

namespace TheaterAdmin.Infrastructure.Persistence
{
    public class Manager : BaseInfraestructureEntity
    {

        public Manager()
        {
            Events = new HashSet<Event>();
        }

        public string? Name { get; set; }

        public string? Identification { get; set; }

        public string? Pulep { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
