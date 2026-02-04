using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Project:BaseEntity<int>
    {
        public string Title { get; set; }   
        public string Description { get; set; }
        public string? RepoLink { get; set; }
        public string? LiveLink { get; set; }

        public List<ProjectImages> ProjectImages { get; set; } = new();

        public List<ProjectTechnologies> ProjectTechnologies { get; set; } = new();

    }
}
