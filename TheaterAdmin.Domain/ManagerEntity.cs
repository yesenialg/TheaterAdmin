using TheaterAdmin.Domain.Common;

namespace TheaterAdmin.Domain
{
    public class ManagerEntity : BaseDomainEntity
    {
        public string? Name { get; set; }

        public string? Identification { get; set; }

        public string? Pulep { get; set; }
    }
}
