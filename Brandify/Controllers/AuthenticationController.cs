using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abastraction.Contracts;
using shared.DTOs.AuthDtos;

namespace Brandify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthService _authservice) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<ActionResult<AuthResultDto>> Register (registrDto registerDtos)
        {
            return Ok(await _authservice.Register(registerDtos)); 
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResultDto>> Login(LoginDto LoginDtos)
        {
            return Ok(await _authservice.Login(LoginDtos));
        }
    }
}
