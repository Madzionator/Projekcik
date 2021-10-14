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
            CreateMap<Keyword, KeywordDto>().ReverseMap();
            CreateMap<Keyword, KeywordEditDto>().ReverseMap();
            CreateMap<Job, JobStatsDto>()
                .ForMember(x => x.CandidateCount, opts => opts.MapFrom(x => x.Candidates.Count));
            CreateMap<Keyword, KeywordStatsDto>()
                .ForMember(x => x.CandidateCount, opts => opts.MapFrom(x => x.Candidate.Count));
        }
    }
}