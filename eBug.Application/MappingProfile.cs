﻿using AutoMapper;
using eBug.Application.Features.Bugs.Commands.CreateBug;
using eBug.Application.Features.Bugs.Queries.GetAllBugs;
using eBug.Domain.Entities;

namespace eBug.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bug, CreateBugCommand>().ReverseMap();
            CreateMap<Bug, GetAllBugsResponse>();
        }
    }
}