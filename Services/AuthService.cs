using CRMCallCenter.Data;
using CRMCallCenter.Models;
using CRMCallCenter.Models.Uzytkownicy.Response;
using CRMCallCenter.Models.Uzytkownicy.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CRMCallCenter.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using CRMCallCenter.Models.Uzytkownicy;


namespace CRMCallCenter.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;


        public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        
        public async Task<AuthResponse?> LoginAsync(CRMCallCenter.Models.Uzytkownicy.Request.LoginRequest request)
        {
            var user = await _context.Uzytkownicy
                .Include(u => u.Rola)
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Haslo, user.HasloHash))
                return null;

            var claims = new List<Claim>
            {
            
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Rola.Nazwa)
            
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:ExpiresInMinutes"]));

            var token = new JwtSecurityToken(

                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds

                );

            return new AuthResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = expires
            };
        }


        public async Task<bool> RegisterAsync(CRMCallCenter.Models.Uzytkownicy.Request.RegisterRequest request)
        {

            if (await _context.Uzytkownicy.AnyAsync(u => u.Email == request.Email))
                return false;

            var rola = await _context.Role.FindAsync(request.RolaId);
            if (rola == null) return false;

            var user = new Uzytkownik
            {

                Imie = request.Imie,
                Nazwisko = request.Nazwisko,
                Email = request.Email,
                HasloHash = BCrypt.Net.BCrypt.HashPassword(request.Haslo),
                Rola = rola,
                ZespolId = request.ZespolId,
                PrzelozonyId = request.PrzelozonyId

            };

            _context.Uzytkownicy.Add(user);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
