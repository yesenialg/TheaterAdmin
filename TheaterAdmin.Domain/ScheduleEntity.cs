using TheaterAdmin.Domain.Common;

namespace TheaterAdmin.Domain
{
    public class ScheduleEntity : BaseDomainEntity
    {
        public DateTime DateTime { get; set; }

        public EventEntity? Event { get; set; }

    }
}
