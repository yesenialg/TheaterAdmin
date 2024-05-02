using TheaterAdmin.Infrastructure.Persistence.Common;

namespace TheaterAdmin.Infrastructure.Persistence
{
    public class Schedule : BaseInfraestructureEntity
    {
        public DateTime DateTime { get; set; }

        public int EventId { get; set; }

        public virtual Event? Event { get; set; }
    }
}
