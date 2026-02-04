using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presistance.Data.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasMany(p=>p.ProjectImages).WithOne(pi => pi.Project)
                   .HasForeignKey(pi => pi.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(p=>p.ProjectTechnologies).WithOne(pt => pt.Project)
                   .HasForeignKey(pt => pt.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
