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
        [SwaggerOperation(Summary = "Đăng nhập")]
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

        [HttpPost("account")]
        [Authorize(Roles = "1,2")] // Admin hoặc Nhân sự
        [SwaggerOperation(Summary = "Cấp tài khoản")]
        public async Task<IActionResult> CapTaiKhoan([FromBody] CapTaiKhoanDTO dto)
        {
            try
            {
                var (thanhCong, thongBao) = await _authService.CapTaiKhoanAsync(dto);

                if (!thanhCong)
                    return BadRequest(new { thanhCong = false, thongBao });

                return Ok(new { thanhCong = true, thongBao });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    thanhCong = false,
                    thongBao = $"Lỗi khi cấp tài khoản: {ex.Message}"
                });
            }
        }

        [HttpPost("password")]
        [Authorize]
        [SwaggerOperation(Summary = "Đổi mật khẩu")]
        public async Task<IActionResult> DoiMatKhau([FromBody] DoiMatKhauDTO dto)
        {
            try
            {
                if(dto.MatKhauMoi.Length < 6)
                {
                    return BadRequest(new
                    {
                        thanhCong = false,
                        thongBao = "Mật khẩu mới phải có ít nhất 6 ký tự."
                    });
                }
                var maNv = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(maNv))
                    return Unauthorized(new { thanhCong = false, thongBao = "Không xác định được người dùng." });

                var (thanhCong, thongBao) = await _authService.DoiMatKhauAsync(maNv, dto);

                if (!thanhCong)
                    return BadRequest(new { thanhCong = false, thongBao });

                return Ok(new { thanhCong = true, thongBao });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    thanhCong = false,
                    thongBao = $"Lỗi khi đổi mật khẩu: {ex.Message}"
                });
            }
        }
    }
}
