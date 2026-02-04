using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.DTOs.ProjectRequestDto
{
    public class ProjectReuqestResultDto
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Address { get; set; }
        public string ProjectDetails { get; set; }
        public string ServiceType { get; set; }
    }
}
