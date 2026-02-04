using Domain.Models;
using Domain.Models.Identity;
using Domain.Models.ProjectRequestModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace presistance.Data
{
    public class BrandifyDbContext(DbContextOptions<BrandifyDbContext> options):IdentityDbContext<ApplicationUser>(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BrandifyDbContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Technologies> Technologies { get; set; }

        public DbSet<ProjectTechnologies> ProjectTechnologies { get; set; }

        public DbSet<ProjectImages> ProjectImages { get; set; }

        public DbSet<ProjectRequest> projectRequests { get; set; }

       
    }
}
