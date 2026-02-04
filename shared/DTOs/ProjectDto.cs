using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RepoLink { get; set; }
        public string LiveLink { get; set; }

        public List<ProjectImagesDto> ProjectImages { get; set; }

        public List<TechnologiesDto> Technologies { get; set; }
    }
}
