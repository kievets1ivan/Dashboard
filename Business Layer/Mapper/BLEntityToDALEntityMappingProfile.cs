using AutoMapper;
using Business_Layer.EntitiesBL;
using DAL.Entities;

namespace Business_Layer.Mapper
{
    public class BlEntityToDalEntityMappingProfile : Profile
    {
        public BlEntityToDalEntityMappingProfile() 
        {
            CreateMap<TicketBL, TicketEntity>();

            CreateMap<TicketEntity, TicketBL>();
        }
    }
}
