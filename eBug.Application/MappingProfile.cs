using AutoMapper;
using eBug.Application.Contracts.Bugs;
using eBug.Application.Features.Bugs.Commands.CreateBug;
using eBug.Application.Features.Bugs.Queries.GetAllBugs;
using eBug.Application.Features.Projects.Queries.GetAllProjects;
using eBug.Domain.Entities;

namespace eBug.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bug, CreateBugCommand>();
            CreateMap<Bug, GetAllBugsResponse>();
            CreateMap<Project, GetAllProjectResponse>();
        }
    }
}