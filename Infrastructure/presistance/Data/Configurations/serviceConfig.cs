using Domain.Models.ServicesModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presistance.Data.Configurations
{
    public class serviceConfig : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
                builder.HasMany(sc=>sc.Services).WithOne(s=>s.ServiceCategory).HasForeignKey(s=>s.ServiceCategoryId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
