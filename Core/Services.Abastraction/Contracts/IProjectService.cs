using shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abastraction.Contracts
{
    public interface IProjectService
    {
        //project part
        public Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();

        public Task<ProjectDto> GetProjectByIdAsync(int id);

        public Task<ProjectDto> CreateProjectAsync(CreateOrUpdateProjectDto projectDto);

        public Task<ProjectDto> UpdateProjectAsync(int id, UpdateProjectDto projectDto);

        public Task<bool> DeleteProjectAsync(int id);

        //technology part 

        public Task<IEnumerable<TechnologiesDto>> GetAllTechnologiesAsync();

        public Task<TechnologiesDto> GetTechnologyByIdAsync(int id);

        public Task<TechnologiesDto> CreateTechnologyAsync(CreateOrUpdateTechnologyDto technologiesDto);

        public Task<TechnologiesDto> UpdateTechnologyAsync(int id, CreateOrUpdateTechnologyDto technologiesDto);

        public Task<bool> DeleteTechnologyAsync(int id);

    }
}
