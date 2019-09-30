using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business_Layer.DTO;
using DAL.Entities;

namespace Business_Layer
{
    public static class AutomapperConfig
    {
        public static IMapper ConfigurationMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TicketEntity, TicketDtoService>().
                    ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id)).
                    ForMember(dest => dest.Priority, act => act.MapFrom(src => src.Priority)).
                    ForMember(dest => dest.Status, act => act.MapFrom(src => src.Status)).
                    ForMember(dest => dest.Theme, act => act.MapFrom(src => src.Theme)).
                    ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description)).
                    ForMember(dest => dest.IsDelete, act => act.MapFrom(src => src.IsDelete));
                cfg.CreateMap<TicketDtoService, TicketEntity>().
                    ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id)).
                    ForMember(dest => dest.Priority, act => act.MapFrom(src => src.Priority)).
                    ForMember(dest => dest.Status, act => act.MapFrom(src => src.Status)).
                    ForMember(dest => dest.Theme, act => act.MapFrom(src => src.Theme)).
                    ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description)).
                    ForMember(dest => dest.IsDelete, act => act.MapFrom(src => src.IsDelete));
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}
