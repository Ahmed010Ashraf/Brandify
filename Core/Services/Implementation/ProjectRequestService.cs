using AutoMapper;
using Domain.Contracts;
using Domain.Models.ProjectRequestModel;
using Services.Abastraction.Contracts;
using shared.DTOs.ProjectRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ProjectRequestService(IUnitOfWork _Uow , IMapper _mapper) : IProjectRequestService
    {
        public async Task<ProjectReuqestResultDto> CreateProjectReuqest(CreateOrUpdateProjectRequestDto createOrUpdateProjectRequestDto)
        {
            var project = _mapper.Map<ProjectRequest>(createOrUpdateProjectRequestDto);
            await _Uow.GetRepository<ProjectRequest>().AddAsync(project);
            await _Uow.SaveChangesAsync();
            return _mapper.Map<ProjectReuqestResultDto>(project);
        }

        public async Task<IEnumerable<ProjectReuqestResultDto>> GetProjectReuqests()
        {
            var projects = await _Uow.GetRepository<ProjectRequest>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectReuqestResultDto>>(projects);
        }
    }
}
