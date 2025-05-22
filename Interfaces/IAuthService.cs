using MyLoginRequest = CRMCallCenter.Models.Uzytkownicy.Request.LoginRequest;
using MyRegisterRequest = CRMCallCenter.Models.Uzytkownicy.Request.RegisterRequest;
using CRMCallCenter.Models.Uzytkownicy.Response;
using Microsoft.AspNetCore.Identity.Data;

namespace CRMCallCenter.Interfaces

{
    public interface IAuthService
    {
        Task<AuthResponse?> LoginAsync(MyLoginRequest request);
        Task<bool> RegisterAsync(MyRegisterRequest request);
    }
}
