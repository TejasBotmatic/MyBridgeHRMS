using Microsoft.IdentityModel.Tokens;
using MyBridgeHRMS.JwtContext;
using MyBridgeHRMS.AuthModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using MyBridgeHRMS.Auth;
using MyBridgeHRMS.Models;
using Microsoft.AspNetCore.Mvc;
using MyBridgeHRMS.Dtos;
using MyBridgeHRMS.Data;
using System.Data;

namespace MyBridgeHRMS.AuthServices
{
    public class AuthServices : IAuthServices
    {
        private readonly JwtDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly DbHelper _dbHelper;


        public AuthServices(JwtDbContext context, IConfiguration configuration, DbHelper dbHelper)
        {
            _context = context;
            _configuration = configuration;
            _dbHelper = dbHelper;
        }


        public async Task<int> AddUser(EmployeeInsertRequestDto employeeDto)
        {
            var parameters = new Dictionary<string, object>
            {
                 { "p_UserId", employeeDto.UserId },
                    { "p_Name", employeeDto.Name },
                    { "p_Salary", employeeDto.Salary },
                    { "p_AccountType", employeeDto.AccountType },
                    { "p_Address", employeeDto.Address },
                    { "p_AnnualCtc", employeeDto.AnnualCtc },
                    { "p_BiometricEmpId", employeeDto.BiometricEmpId },
                    { "p_BranchId", employeeDto.BranchId },
                    { "p_Childern", employeeDto.Children },
                    { "p_CompanyDoj", employeeDto.CompanyDoj },
                    { "p_CreatedBy", employeeDto.CreatedBy },
                    { "p_DepartmentId", employeeDto.DepartmentId },
                    { "p_DesignationId", employeeDto.DesignationId },
                    { "p_Dob", employeeDto.Dob },
                    { "p_Documents", employeeDto.Documents },
                    { "p_Email", employeeDto.Email },
                    { "p_EmployeeId", employeeDto.EmployeeId },
                    { "p_Gender", employeeDto.Gender },
                    { "p_IsActive", employeeDto.IsActive },
                    { "p_ManagerId", employeeDto.ManagerId },
                    { "p_MaritalStatus", employeeDto.MaritalStatus },
                    { "p_Password", employeeDto.Password },
                    { "p_Phone", employeeDto.Phone },
                    { "p_RefreshToken", employeeDto.RefreshToken },
                    { "p_RefreshTokenExpire", employeeDto.RefreshTokenExpire },
                    { "p_RoleId", employeeDto.RoleId },
                    { "p_SalaryBand", employeeDto.SalaryBand },
                    { "p_SalaryType", employeeDto.SalaryType }

            };

            return await _dbHelper.ExecuteNonQueryAsync("sp_InsertEmployee", parameters);
        }

        public async Task<string> GenerateAndAssignRefreshToken(Employees user)
        {
            var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpire = DateTime.UtcNow.AddDays(2);

            _context.employees.Update(user);
            await _context.SaveChangesAsync();

            return refreshToken;
        }


        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if(jwtSecurityToken == null ||
     !(jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase) ||
       jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase)))
                {
                throw new SecurityTokenException("Invalid token");
            }
                

            return principal;
        }

        public async Task<bool> UpdateUser(Employees user)
        {
            _context.employees.Attach(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<string> GenerateAccessToken(Employees user)
        {
            if (user == null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.Name)
            };

            var roleId = await _context.employees
                .Where(u => u.Id == user.Id)
                .Select(u => u.RoleId)
                .FirstOrDefaultAsync();

            var roles = await _context.Roles.Where(r => r.Id == roleId).ToListAsync();
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        public async Task<LoginUserResDto> Login(LoginRequestDto loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
                throw new Exception("Credentials are not valid");

            var user = await _context.employees
                .SingleOrDefaultAsync(s => s.Name == loginRequest.Username && s.Password == loginRequest.Password);

            if (user == null)
                throw new Exception("User is not valid");

            var accessToken = await GenerateAccessToken(user);
            var refreshToken = await GenerateAndAssignRefreshToken(user);
            LoginUserResDto resp = new LoginUserResDto()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return resp;

           
        }



        public async Task<(string newAccessToken, string newRefreshToken)> RefreshToken(string expiredAccessToken, string refreshToken)
        {
            var principal = GetPrincipalFromExpiredToken(expiredAccessToken);
            if (principal == null)
                throw new SecurityTokenException("Invalid access token");

            var userId = int.Parse(principal.FindFirst("Id")?.Value);
            var user = await _context.employees.SingleOrDefaultAsync(u => u.Id == userId);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpire <= DateTime.UtcNow)
                throw new SecurityTokenException("Invalid refresh token");

            var newAccessToken = await GenerateAccessToken(user);
            var newRefreshToken = await GenerateAndAssignRefreshToken(user);

            return (newAccessToken, newRefreshToken);
        }


    }
}
