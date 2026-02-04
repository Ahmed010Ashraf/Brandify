using AutoMapper;
using Domain.Contracts;
using Domain.Models.ServicesModule;
using shared.DTOs;
using shared.DTOs.serviceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Services.Abastraction.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Services.Implementation
{
    public class ServiceServices(IUnitOfWork _UOW , IMapper _mapper , IAttachmentService _attach) : IServiceServices
    {
        public async Task<ServiceCategoryResultDto> CreateServiceCatigoryDto(CreateOrUpdateServiceCategoryDto servicecategoryDto)
        {
            var repo =  _UOW.GetRepository<ServiceCategory>();
            var serviceCategory = _mapper.Map<ServiceCategory>(servicecategoryDto);

            await repo.AddAsync(serviceCategory);
            var res = await _UOW.SaveChangesAsync();

                return _mapper.Map<ServiceCategoryResultDto>(serviceCategory);
            

            
        }

        

        public async Task<ServiceDto> CreateServices(CreateOrUpdateServiceDto CreateOrUpdateServiceDto)
        {
            var service = new Service()
            {
                Title = CreateOrUpdateServiceDto.Title,
                Description = CreateOrUpdateServiceDto.Description,
                IconUrl = _attach.Upload(CreateOrUpdateServiceDto.IconUrl),
                ServiceCategoryId = CreateOrUpdateServiceDto.ServiceCategoryId,

            };

            await _UOW.GetRepository<Service>().AddAsync(service);

            var IsCreated =await _UOW.SaveChangesAsync();

            return _mapper.Map<ServiceDto>(service);
        }

        public async Task<bool> DeleteServicCategoryeDto(int id)
        {
            var repo = _UOW.GetRepository<ServiceCategory>();
            var servicecategory = await repo.GetByIdAsync(id);
             repo.DeleteAsync(servicecategory);
            var res = await _UOW.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> DeleteServices(int id)
        {
            var repo = _UOW.GetRepository<Service>();
            var service = await repo.GetByIdAsync(id);
            repo.DeleteAsync(service);
            var res = await _UOW.SaveChangesAsync();
            return res > 0;
        }

        public async Task<IEnumerable<ServiceCategoryResultDto>> GetAllServiceCatigories()
        {
            var AllServiceCategories = await _UOW.GetRepository<ServiceCategory>().GetAllAsync(q=>q.Include(q=>q.Services));
            return _mapper.Map<IEnumerable<ServiceCategoryResultDto>>(AllServiceCategories);
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServices()
        {
            var AllServices = await _UOW.GetRepository<Service>().GetAllAsync();
            return _mapper.Map<IEnumerable<ServiceDto>>(AllServices);
        }

        public async Task<ServiceCategoryResultDto> GetServiceCatigoriesById(int id)
        {
            var ServiceCat = await _UOW.GetRepository<ServiceCategory>().GetByIdAsync(id);
            return _mapper.Map<ServiceCategoryResultDto>(ServiceCat);   
        }

      

        public async Task<ServiceDto> GetServicesById(int id)
        {
            var Service = await _UOW.GetRepository<Service>().GetByIdAsync(id);
            return _mapper.Map<ServiceDto>(Service);
        }

        public async Task<ServiceCategoryResultDto> UpdateServiceCatigoryDto(int id , CreateOrUpdateServiceCategoryDto servicecatDto)
        {
            var ServiceCat = await _UOW.GetRepository<ServiceCategory>().GetByIdAsync(id) ?? throw new ServiceCatigoryNotFoundException(id);
            ServiceCat.Title = servicecatDto.Title;
            ServiceCat.Description = servicecatDto.Description;
            _UOW.GetRepository<ServiceCategory>().UpdateAsync(ServiceCat);
            await _UOW.SaveChangesAsync();
            return _mapper.Map<ServiceCategoryResultDto>(ServiceCat);
        }

  

        public async Task<ServiceDto> UpdateServices(int id , CreateOrUpdateServiceDto CreateOrUpdateServiceDto)
        {
            var repo = _UOW.GetRepository<Service>();
            var service = await repo.GetByIdAsync(id);
            _attach.Delete(service.IconUrl);
            service.Title = CreateOrUpdateServiceDto.Title;
            service.Description = CreateOrUpdateServiceDto.Description;
            service.ServiceCategoryId = CreateOrUpdateServiceDto.ServiceCategoryId;
            service.IconUrl = _attach.Upload(CreateOrUpdateServiceDto.IconUrl);

            repo.UpdateAsync(service);
            await _UOW.SaveChangesAsync();

            return _mapper.Map<ServiceDto>(service);
        }

     
    }
}
