using AutoMapper;
using eBug.Application.Features.Bugs.Commands.CreateBug;
using eBug.Domain.Entities;

namespace eBug.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bug, CreateBugCommand>().ReverseMap();
        }
    }
}