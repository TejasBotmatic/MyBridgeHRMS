using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MyBridgeHRMS.AuthModels;
using System.Security.Claims;

namespace MyBridgeHRMS.Auth
{
    public interface IAuthServices
    {
           
            Task<User> AddUser(User user);
            Task<string> GenerateAndAssignRefreshToken(User user);
            ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
            Task<bool> UpdateUser(User user);
            Task<string> GenerateAccessToken(User user);
            Task<LoginUserResDto> Login(LoginRequestDto loginRequest);
        Task<(string newAccessToken, string newRefreshToken)> RefreshToken(string expiredAccessToken, string refreshToken); 
        }
    }
