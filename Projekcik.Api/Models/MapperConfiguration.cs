﻿using AutoMapper;
using Projekcik.Api.Controllers;
using Projekcik.Database.Models;

namespace Projekcik.Api.Models
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}