using AutoMapper.Configuration;
using System;
using Business_Layer.Mapper;
using AutoMapper;

namespace Web.Mappper
{
    public static class MapperModule
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToBlEntityMappingProfile>();
                cfg.AddProfile<BlEntityToDalEntityMappingProfile>();
            });

            return config;
        }
    }
}