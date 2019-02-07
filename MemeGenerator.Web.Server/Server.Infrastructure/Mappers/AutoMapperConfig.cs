using AutoMapper;
using Server.Core.Domain;
using Server.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Meme, MemeDto>();
                cfg.CreateMap<User, UserDto>();
            })
            .CreateMapper();
    }
}
