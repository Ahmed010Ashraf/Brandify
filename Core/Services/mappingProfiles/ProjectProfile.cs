using AutoMapper;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.mappingProfiles
{
    public class ProjectProfile:Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectImages, ProjectImagesDto>().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<PicUrlResolver>());
            CreateMap<CreateOrUpdateProjectImageDto, ProjectImages>();

            CreateMap<Technologies, TechnologiesDto>().ForMember(dest=>dest.IconUrl, opt => opt.MapFrom<PicTechUrlResolver>());
            CreateMap<CreateOrUpdateTechnologyDto, Technologies>();


            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.ProjectImages, opt => opt.MapFrom(src => src.ProjectImages))
                .ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.ProjectTechnologies.Select(pt=>pt.Technologies)));

            CreateMap<ProjectImagesDto, ProjectImages>();
                
            CreateMap<CreateOrUpdateProjectDto, Project>()
                .ForMember(dest => dest.ProjectImages, opt => opt.MapFrom(src => src.Images))
                .ForMember(dest => dest.ProjectTechnologies, opt => opt.Ignore());


            
        }
    }

    public class PicUrlResolver(IConfiguration configurations) : IValueResolver<ProjectImages, ProjectImagesDto, string>
    {
        public string Resolve(ProjectImages source, ProjectImagesDto destination, string destMember, ResolutionContext context)
        {
            if(source.ImageUrl is not null)
            {
                return $"{configurations.GetSection("URLs")["BaseUrl"]}{source.ImageUrl}";
            }
            return null;
        }
    }


    public class PicTechUrlResolver(IConfiguration configurations) : IValueResolver<Technologies, TechnologiesDto, string>
    {
        public string Resolve(Technologies source, TechnologiesDto destination, string destMember, ResolutionContext context)
        {
            if (source.IconUrl is not null)
            {
                return $"{configurations.GetSection("BaseUrl")["BaseUrl"]}{source.IconUrl}";
            }
            return null;
        }
    }
}
