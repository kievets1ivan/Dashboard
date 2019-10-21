using AutoMapper;
using Business_Layer.EntitiesBL;
using Web.Models;

namespace Web.Mappper
{
    public class ViewModelToBlEntityMappingProfile : Profile
    {
        public ViewModelToBlEntityMappingProfile()
        {
            CreateMap<TicketViewModel, TicketBL>();

            CreateMap<TicketBL, TicketViewModel>();
        }
    }
}