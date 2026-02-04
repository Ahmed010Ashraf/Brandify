using AutoMapper;
using Domain.Models.ProjectRequestModel;
using shared.DTOs.ProjectRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.mappingProfiles
{
    public class ProjectReuqestProfile : Profile
    {
        public ProjectReuqestProfile()
        {
            CreateMap<ProjectRequest, ProjectReuqestResultDto>();
            CreateMap<CreateOrUpdateProjectRequestDto, ProjectRequest>();
        }
    }
}
