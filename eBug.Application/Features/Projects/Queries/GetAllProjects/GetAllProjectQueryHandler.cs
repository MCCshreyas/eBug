using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using eBug.Application.Abstractions.Persistence;
using eBug.Domain.Entities;
using MediatR;

namespace eBug.Application.Features.Projects.Queries.GetAllProjects
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, List<GetAllProjectResponse>>
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IMapper _mapper;

        public GetAllProjectQueryHandler(IAsyncRepository<Project> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllProjectResponse>> Handle(GetAllProjectQuery request,
            CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.ListAllAsync();
            return _mapper.Map<List<GetAllProjectResponse>>(projects);
        }
    }
}