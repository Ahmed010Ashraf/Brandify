using shared.DTOs;
using shared.DTOs.serviceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abastraction.Contracts
{
    public interface IServiceServices
    {
        Task<IEnumerable<ServiceCategoryResultDto>> GetAllServiceCatigories();
        Task<ServiceCategoryResultDto> GetServiceCatigoriesById(int id);

        Task<ServiceCategoryResultDto> CreateServiceCatigoryDto(CreateOrUpdateServiceCategoryDto serviceDto);
        Task<ServiceCategoryResultDto> UpdateServiceCatigoryDto(int id ,CreateOrUpdateServiceCategoryDto serviceDto);

        Task<bool> DeleteServicCategoryeDto(int id);

        ////
        ///
        Task<IEnumerable<ServiceDto>> GetAllServices();
        Task<ServiceDto> GetServicesById(int id);
        Task<ServiceDto> CreateServices(CreateOrUpdateServiceDto CreateOrUpdateServiceDto);
        Task<ServiceDto> UpdateServices(int id, CreateOrUpdateServiceDto CreateOrUpdateServiceDto);
        Task<bool> DeleteServices(int id);

    }
}
