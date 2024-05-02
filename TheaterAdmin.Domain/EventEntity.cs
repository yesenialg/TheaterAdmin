using TheaterAdmin.Domain.Common;

namespace TheaterAdmin.Domain
{
    public class EventEntity : BaseDomainEntity
    {
        public string? Name { get; set; }
        public ManagerEntity? Manager { get; set; }
    }

}
