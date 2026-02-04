using AutoMapper;
using Domain.Models;
using Domain.Models.ServicesModule;
using Microsoft.Extensions.Configuration;
using shared.DTOs;
using shared.DTOs.serviceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.mappingProfiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service,ServiceDto>().ForMember(dest=>dest.IconUrl , opt=>opt.MapFrom<PicServiceUrlResolver>());
            CreateMap<ServiceCategory,ServiceCategoryResultDto>();
            CreateMap<CreateOrUpdateServiceCategoryDto,ServiceCategory>();
        }


        public class PicServiceUrlResolver(IConfiguration configurations) : IValueResolver<Service, ServiceDto, string>
        {
          

            public string Resolve(Service source, ServiceDto destination, string destMember, ResolutionContext context)
            {
                if (source.IconUrl is not null)
                {
                    return $"{configurations.GetSection("URLs")["BaseUrl"]}{source.IconUrl}";
                }
                return null;
            }
        }
    }
}
