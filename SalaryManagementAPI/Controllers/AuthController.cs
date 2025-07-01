
using Microsoft.AspNetCore.Authorization;

namespace SalaryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDto)
        {
            try
            {
                var result = await _authService.LoginAsync(loginDto);
                if (!result.ThanhCong)
                {
                    return Unauthorized(new
                    {
                        ThanhCong = false,
                        ThongBao = result.ThongBao,
                    });
                }
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = result.ThongBao,
                    DuLieu = new { Token = result.Token }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi đăng nhập: {ex.Message}",
                });
            }
            
        }
    }
}
