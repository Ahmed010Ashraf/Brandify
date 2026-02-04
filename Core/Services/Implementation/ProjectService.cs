using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using Services.Abastraction.Contracts;
using shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services.Implementation
{
    public class ProjectService(IUnitOfWork _UOW , IMapper _mapper , IAttachmentService _attachmentservice) : IProjectService
    {
        public async Task<ProjectDto> CreateProjectAsync(CreateOrUpdateProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            for (var i = 0; i < projectDto.Images.Count; i++) {
                project.ProjectImages[i].ImageUrl = _attachmentservice.Upload(projectDto.Images[i].ImageUrl);
                project.ProjectImages[i].ImageOrder = projectDto.Images[i].ImageOrder;
            }

            foreach (var techId in projectDto.Technologies)
            {
                project.ProjectTechnologies.Add(new ProjectTechnologies
                {
                    TechnologiesId = techId
                });
            }

            await _UOW.GetRepository<Project>().AddAsync(project);
            await _UOW.SaveChangesAsync();

            var res =  _mapper.Map<ProjectDto>(project);
       
            return res;

        }

        public async Task<TechnologiesDto> CreateTechnologyAsync(CreateOrUpdateTechnologyDto technologiesDto)
        {
            var tech = _mapper.Map<Technologies>(technologiesDto);

            tech.IconUrl =  _attachmentservice.Upload(technologiesDto.IconUrl);

           await _UOW.GetRepository<Technologies>().AddAsync(tech);
            await _UOW.SaveChangesAsync();

            return _mapper.Map<TechnologiesDto>(tech);
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await _UOW.GetRepository<Project>().GetByIdAsync(id);
             _UOW.GetRepository<Project>().DeleteAsync(project);
           var res = await _UOW.SaveChangesAsync();
            return res>0? true: false;
        }

        public async Task<bool> DeleteTechnologyAsync(int id)
        {
            var Technologie = await _UOW.GetRepository<Technologies>().GetByIdAsync(id);
            _UOW.GetRepository<Technologies>().DeleteAsync(Technologie);
            var res = await _UOW.SaveChangesAsync();
            return res > 0 ? true : false;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            var projects = await _UOW.GetRepository<Project>().GetAllAsync(q => q
                .Include(p => p.ProjectImages)
                .Include(p => p.ProjectTechnologies)
                    .ThenInclude(pt => pt.Technologies)
            );

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<ProjectDto> GetProjectByIdAsync(int id)
        {
            var project = await _UOW.GetRepository<Project>().GetByIdAsync(p => p.Id == id, q => q
                .Include(p => p.ProjectImages)
                .Include(p => p.ProjectTechnologies)
                    .ThenInclude(pt => pt.Technologies));

            return _mapper.Map<ProjectDto>(project);
        }


        public async Task<IEnumerable<TechnologiesDto>> GetAllTechnologiesAsync()
        {
            var techs = await _UOW.GetRepository<Technologies>().GetAllAsync();

            return _mapper.Map<IEnumerable<TechnologiesDto>>(techs);
        }

      
        public async Task<TechnologiesDto> GetTechnologyByIdAsync(int id)
        {
            var tech = await _UOW.GetRepository<Technologies>().GetByIdAsync(id);
            return _mapper.Map<TechnologiesDto>(tech);
        }

        public async Task<ProjectDto> UpdateProjectAsync(int id, UpdateProjectDto projectDto)
        {
            var project = await _UOW.GetRepository<Project>().GetByIdAsync(p=>p.Id == id 
            , p=>p.Include(p=>p.ProjectImages).Include(p=>p.ProjectTechnologies).ThenInclude(t=>t.Technologies));

            project.Title = projectDto.Title;
            project.Description = projectDto.Description;
            project.LiveLink = projectDto.LiveLink;
            project.RepoLink = projectDto.RepoLink;



            ///////////////////////////////////////////////////////////
            /////update tech
            
            var projeTech = new List<ProjectTechnologies>();
            foreach(var tech in projectDto.Technologies)
            {
                projeTech.Add(new ProjectTechnologies()
                {
                    TechnologiesId = tech
                });
            }

            project.ProjectTechnologies = projeTech;

            ////////////////////////////////////////////////////////////////////////////////////////
            ///update imgage
            foreach(var img in projectDto.Images)
            {
                if(img.Id == null)
                {
                    project.ProjectImages.Add(new ProjectImages()
                    {
                        ImageOrder = img.ImageOrder,
                        ImageUrl =  _attachmentservice.Upload(img.ImageUrl)
                    });
                }
            }

            _UOW.GetRepository<Project>().UpdateAsync(project);
           await _UOW.SaveChangesAsync();

            return _mapper.Map<ProjectDto>(project);




        }

        public async Task<TechnologiesDto> UpdateTechnologyAsync(int id, CreateOrUpdateTechnologyDto technologiesDto)
        {
            var tech = await _UOW.GetRepository<Technologies>().GetByIdAsync(id);
            
            _mapper.Map(technologiesDto,tech);

            if(tech.IconUrl != null)
            {
                _attachmentservice.Delete(tech.IconUrl);
            }

            tech.IconUrl = _attachmentservice.Upload(technologiesDto.IconUrl);

             _UOW.GetRepository<Technologies>().UpdateAsync(tech);
            await _UOW.SaveChangesAsync();

            return _mapper.Map<TechnologiesDto>(tech);
        }
    }
}
