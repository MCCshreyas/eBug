using AutoMapper;
using eBug.Application.Contracts.Bugs;
using eBug.Application.Features.Projects.Queries.GetAllProjects;
using eBug.Domain.Entities;

namespace eBug.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bug, CreateBugCommand>();
            CreateMap<Bug, GetAllBugsResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.CreatedBy));
            CreateMap<Bug, GetBugDetailsByIdResponse>();
            CreateMap<Bug, GetAllBugsByProjectResponse>();
            CreateMap<Project, GetAllProjectResponse>();
        }
    }
}