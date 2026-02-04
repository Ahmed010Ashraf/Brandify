using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abastraction.Contracts;
using Services.Implementation;
using shared.DTOs.serviceDto;

namespace Brandify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController(IServiceServices _service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GettAllServices()
        {
            var res = await _service.GetAllServices();
            return Ok(res);   
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDto>> CreateService(CreateOrUpdateServiceDto serviceDto)
        {
            var res = await _service.CreateServices(serviceDto);
            return Ok(res);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ServiceDto>> UpdateService(int id , CreateOrUpdateServiceDto serviceDto)
        {
            var res = await _service.UpdateServices(id,serviceDto);
            return Ok(res);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteService(int id)
        {
            var res = await _service.DeleteServices(id);
            return res;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceDto>> GetServiceById (int id)
        {
            var res = await _service.GetServicesById(id);
            return Ok(res);
        }


        ////////////////////service category/////////////////////////
        [HttpGet("Category")]
        public async Task<ActionResult<IEnumerable<ServiceCategoryResultDto>>> GettAllServicesCategory()
        {
            var res = await _service.GetAllServiceCatigories();
            return Ok(res);
        }

        [HttpPost("Category")]
        public async Task<ActionResult<ServiceCategoryResultDto>> CreateServiceCategory(CreateOrUpdateServiceCategoryDto serviceDto)
        {
            var res = await _service.CreateServiceCatigoryDto(serviceDto);
            return Ok(res);
        }

        [HttpPut("Category/{id:int}")]
        public async Task<ActionResult<ServiceCategoryResultDto>> UpdateServiceCategory(int id, CreateOrUpdateServiceCategoryDto serviceDto)
        {
            var res = await _service.UpdateServiceCatigoryDto(id, serviceDto);
            return Ok(res);
        }

        [HttpDelete("Category/{id:int}")]
        public async Task<ActionResult<bool>> DeleteServiceCategory(int id)
        {
            var res = await _service.DeleteServicCategoryeDto(id);
            return res;
        }

        [HttpGet("Category/{id:int}")]
        public async Task<ActionResult<ServiceCategoryResultDto>> GetServiceCategoryById(int id)
        {
            var res = await _service.GetServiceCatigoriesById(id);
            return Ok(res);
        }


    }
}
