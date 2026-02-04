using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abastraction.Contracts;
using shared.DTOs;

namespace Brandify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService _projectservice) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects()
        {
            var res = await _projectservice.GetAllProjectsAsync();
            return Ok(res);
        }

        [HttpPost("Create")]

        public async Task<ActionResult<ProjectDto>> CreateProject([FromForm]CreateOrUpdateProjectDto createprojectdto)
        {
            var res = await _projectservice.CreateProjectAsync(createprojectdto);
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectDto>> GetProjetById(int id)
        {
            var res =  await _projectservice.GetProjectByIdAsync(id);
            return Ok(res);
        }


        [HttpDelete]
        public async Task<bool> DeleteProject(int id)
        {
            var res = await _projectservice.DeleteProjectAsync(id);
            return res;
        }

        [HttpPut("Update/{id:int}")] 
        public async Task<ActionResult<ProjectDto>> UpdateProject(int id , UpdateProjectDto updateprojectdto)
        {
            var res = await _projectservice.UpdateProjectAsync(id, updateprojectdto);

            return Ok(res);
        }


        //////////////////////technologies////////////////////////

        [HttpGet("GetAllTechnologies")]
        public async Task<ActionResult<TechnologiesDto>> GetAllTechs()
        {
            return Ok(await _projectservice.GetAllTechnologiesAsync());
        }


        [HttpPost("CreateTechnology")]
        public async Task<ActionResult<TechnologiesDto>> CreateTech(CreateOrUpdateTechnologyDto Dto)
        {
            return Ok(await _projectservice.CreateTechnologyAsync(Dto));
        }

        [HttpPut("UpdateTechnology")]
        public async Task<ActionResult<TechnologiesDto>> CreateTech(int id , CreateOrUpdateTechnologyDto Dto)
        {
            return Ok(await _projectservice.UpdateTechnologyAsync(id,Dto));
        }

        [HttpDelete("DeleteTech")]
        public async Task<ActionResult<bool>> DeleteTech(int id)
        {
            return Ok(await _projectservice.DeleteTechnologyAsync(id));
        }
    }
}
