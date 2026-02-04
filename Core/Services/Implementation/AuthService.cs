using Domain.Exceptions;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Services.Abastraction.Contracts;
using shared.DTOs;
using shared.DTOs.AuthDtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class AuthService(UserManager<ApplicationUser> _usermanager , IOptions<JwtOptions> _options) : IAuthService
    {
        public async Task<AuthResultDto> Login(LoginDto loginDto)
        {
            var user =await _usermanager.FindByEmailAsync(loginDto.Email)?? 
                throw new UnauthorizedException();

            var IsPasswordTrue = await _usermanager.CheckPasswordAsync(user, loginDto.Password);
            if (IsPasswordTrue)
            {
                var result = new AuthResultDto()
                {
                    Name = user.DisplayName,
                    Email = loginDto.Email,
                    Token = await CreateJwtToken(user)
                };
                return result;
            }
            throw new UnauthorizedException();

        }

        public async Task<AuthResultDto> Register(registrDto registerDto)
        {
            var user = new ApplicationUser()
            {
                DisplayName = registerDto.DiaplayName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.Email
            };
            var res = await _usermanager.CreateAsync(user , registerDto.Password);
            if (!res.Succeeded) { 
                var errs  = res.Errors.Select(e=>e.Description).ToList();
                throw new ValidationException(errs);
            }
            await _usermanager.AddToRoleAsync(user, "User");
            return new AuthResultDto()
            {
                Name = user.DisplayName,
                Email = user.Email,
                Token = await CreateJwtToken(user)
            };


        }

        private async Task<string> CreateJwtToken(ApplicationUser user)
        {
            //claims 
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.Name , user.DisplayName)
            };
            var roles = await _usermanager.GetRolesAsync(user);
            foreach (var role in roles) {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            //key
            string MyKey =  _options.Value.Key;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MyKey));
            //creds = key + algorithm
            var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);
            //jwttoken
            var token = new JwtSecurityToken(
     issuer: _options.Value.Issuer,
     audience: _options.Value.Audience,
     claims: claims,
     expires: DateTime.UtcNow.AddDays(_options.Value.ExpirationInDays),
     signingCredentials: creds
 );
            //return token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
