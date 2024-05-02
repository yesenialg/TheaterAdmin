using AutoMapper;
using TheaterAdmin.Application.Features.Events.Commands.CreateEvent;
using TheaterAdmin.Domain;

namespace TheaterAdmin.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateEventCommand, EventEntity>();
        }
    }
}
