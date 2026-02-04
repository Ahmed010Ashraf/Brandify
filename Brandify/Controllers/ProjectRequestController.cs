using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abastraction.Contracts;
using shared.DTOs.ProjectRequestDto;

namespace Brandify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectRequestController(IProjectRequestService _projectRequestService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectReuqestResultDto>>> GetAllProjectRequests()
        {
            return Ok(await _projectRequestService.GetProjectReuqests());
        }
        [HttpPost]
        public async Task<ActionResult<ProjectReuqestResultDto>> CreateProjectReques([FromBody]CreateOrUpdateProjectRequestDto createOrUpdateProjectRequestDto)
        {
            return Ok(await _projectRequestService.CreateProjectReuqest(createOrUpdateProjectRequestDto));
        }
    }
}
