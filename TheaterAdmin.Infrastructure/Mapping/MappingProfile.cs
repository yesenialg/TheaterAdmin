using AutoMapper;
using TheaterAdmin.Domain;
using TheaterAdmin.Infrastructure.Persistence;

namespace TheaterAdmin.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Manager, ManagerEntity>().ReverseMap();
            CreateMap<EventEntity, Event>()
                .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.Manager.Id))
                .ReverseMap();
            CreateMap<Schedule, ScheduleEntity>().ReverseMap();

        }
    }
}
