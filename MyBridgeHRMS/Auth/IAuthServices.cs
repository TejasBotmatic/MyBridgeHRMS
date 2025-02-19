using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MyBridgeHRMS.AuthModels;
using MyBridgeHRMS.Dtos;
using MyBridgeHRMS.Models;
using System.Security.Claims;

namespace MyBridgeHRMS.Auth
{
    public interface IAuthServices
    {
           
            Task<int> AddUser(EmployeeInsertRequestDto employeeDto);
            Task<string> GenerateAndAssignRefreshToken(Employees user);
            ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
            Task<bool> UpdateUser(Employees user);
            Task<string> GenerateAccessToken(Employees user);
            Task<LoginUserResDto> Login(LoginRequestDto loginRequest);
        Task<(string newAccessToken, string newRefreshToken)> RefreshToken(string expiredAccessToken, string refreshToken); 
        }
    }
