using shared.DTOs.ProjectRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abastraction.Contracts
{
    public interface IProjectRequestService
    {
        Task<ProjectReuqestResultDto> CreateProjectReuqest(CreateOrUpdateProjectRequestDto createOrUpdateProjectRequestDto);

        Task<IEnumerable<ProjectReuqestResultDto>> GetProjectReuqests();
    }
}
