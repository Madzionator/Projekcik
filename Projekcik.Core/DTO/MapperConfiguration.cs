using AutoMapper;
using Projekcik.Database.Models;

namespace Projekcik.Core.DTO
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Location, LocationEditDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Job, JobEditDto>().ReverseMap();
            CreateMap<Candidate, CandidateDto>().ReverseMap();
        }
    }
}