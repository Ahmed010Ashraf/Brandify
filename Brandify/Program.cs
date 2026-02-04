
using Domain.Contracts;
using Domain.Models.Identity;
using Domain.Models.ServicesModule;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using presistance.Data;
using presistance.Repositories;
using Services;
using Services.Abastraction.Contracts;
using Services.Implementation;
using shared.DTOs;
using System.Text;
using System.Threading.Tasks;

namespace Brandify
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<BrandifyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                    
            });

            builder.Services.AddScoped<IUnitOfWork, UniteOfWork>();
            builder.Services.AddScoped<IProjectService , ProjectService>();
            builder.Services.AddScoped<IAttachmentService , AttachmentService>();
            builder.Services.AddScoped<IProjectRequestService , ProjectRequestService>();
            builder.Services.AddScoped<IDBSeeding , SeedingData>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IServiceServices, ServiceServices>();
            builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("JWT:JwtOptions")
);
            builder.Services.AddAutoMapper(cfg => { }, typeof(ServiceAssemplayRef).Assembly);
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<BrandifyDbContext>()
                .AddDefaultTokenProviders();


            var jwtoptions = builder.Configuration.GetSection("JWT:JwtOptions").Get<JwtOptions>();
            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtoptions.Issuer,
                    ValidAudience = jwtoptions.Audience,

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtoptions.Key)
                    )
                };
            });

            //builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var dbInit = scope.ServiceProvider.GetRequiredService<IDBSeeding>();
            await dbInit.Seeding();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
