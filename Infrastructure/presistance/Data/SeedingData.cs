using Domain.Contracts;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presistance.Data
{
    public class SeedingData(BrandifyDbContext _context , UserManager<ApplicationUser> _usermanager , RoleManager<IdentityRole> _rolemanager) : IDBSeeding
    {
        public async Task Seeding()
        {
            if( _context.Database.GetPendingMigrations().Any())
            {
                await _context.Database.MigrateAsync();
            }
            if (!_rolemanager.Roles.Any()) {
                var role1 = new IdentityRole()
                {
                    Name = "User"
                };
                var role2 = new IdentityRole()
                {
                    Name = "Admin"
                };
                await _rolemanager.CreateAsync(role2);
                await _rolemanager.CreateAsync(role1);

            }
            if (!_usermanager.Users.Any())
            {
                var AddminUser = new ApplicationUser()
                {
                    DisplayName = "Ahmed Ashraf",
                    Email = "AhmedAboshady590@gmail.com",
                    UserName = "AhmedAboshady590@gmail.com",
                    PhoneNumber = "01558921462"
                };
                await _usermanager.CreateAsync(AddminUser,"Ahmed@Mostafa@Fares@123");
                await _usermanager.AddToRoleAsync(AddminUser , "Admin");
            }
        }
    }
}
