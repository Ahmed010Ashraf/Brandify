using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.DTOs
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? RepoLink { get; set; }
        public string? LiveLink { get; set; }


        public List<UpdateProjectImageDto> Images { get; set; }
        public List<int> Technologies { get; set; }
    }
}
