using shared.DTOs.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abastraction.Contracts
{
    public interface IAuthService
    {
        Task<AuthResultDto> Login(LoginDto loginDto); 
        Task<AuthResultDto> Register(registrDto registerDto); 

    }
}
