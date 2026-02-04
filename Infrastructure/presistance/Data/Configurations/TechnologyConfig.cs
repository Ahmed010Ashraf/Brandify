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
    public class TechnologyConfig : IEntityTypeConfiguration<Technologies>
    {
        public void Configure(EntityTypeBuilder<Technologies> builder)
        {
            builder.HasMany(t => t.ProjectTechnologies).WithOne(pt => pt.Technologies)
                   .HasForeignKey(pt => pt.TechnologiesId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
