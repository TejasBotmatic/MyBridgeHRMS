using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBridgeHRMS.Auth;
using MyBridgeHRMS.AuthModels;
using MyBridgeHRMS.AuthServices;
using MyBridgeHRMS.Dtos;
using MyBridgeHRMS.Models;
using System.Threading.Tasks;

namespace MyBridgeHRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _auth;

        public AuthController(IAuthServices auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto obj)
        {
            LoginUserResDto resp = await _auth.Login(obj);

            
            return Ok(resp);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto req)
        {
            var (newAccessToken, newRefreshToken) = await _auth.RefreshToken(req.AccessToken, req.RefreshToken);

            var response = new RefreshTokenDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };

            return Ok(response);
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser([FromBody] EmployeeInsertRequestDto employeeDto)
        {
            var addedUser = await _auth.AddUser(employeeDto);
            return Ok(addedUser);
        }

    }
}
