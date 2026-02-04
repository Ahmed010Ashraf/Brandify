using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ServicesModule
{
    public class ServiceCategory:BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Service> Services { get; set; }
    }
}
