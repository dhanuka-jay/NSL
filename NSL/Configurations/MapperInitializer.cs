using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NSL.Data;
using NSL.Models;

namespace NSL.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Player, PlayerDTO>().ReverseMap();
            CreateMap<Player, CreatePlayerDTO>().ReverseMap();
        }
    }
}
