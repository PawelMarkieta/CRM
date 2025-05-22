using CRMCallCenter.Models.Uzytkownicy.Request;
using CRMCallCenter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.Data;

namespace CRMCallCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
            

            public AuthController(IAuthService authService)
            {

                _authService = authService;

            }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CRMCallCenter.Models.Uzytkownicy.Request.LoginRequest request)
        {

            var result = await _authService.LoginAsync(request);
            if (result == null) 
                return Unauthorized("Nieprawidłowy email lub hasło");

            return Ok(result);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CRMCallCenter.Models.Uzytkownicy.Request.RegisterRequest request)
        {

            var result = await _authService.RegisterAsync(request);
            if (!result)
                return BadRequest("Użytkownik o podanym adresie email już istnieje lub rola nie istnieje.");

            return Ok("Rejestracja zakończona sukcesem.");

        }

    }

}
