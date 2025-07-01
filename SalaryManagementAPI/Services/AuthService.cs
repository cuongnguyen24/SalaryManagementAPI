

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SalaryManagementAPI.Services.Interfaces
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginRequestDTO loginDto)
        {
            var nguoiDung = await _context.NguoiDungs
                .FirstOrDefaultAsync(nd => nd.TenDangNhap == loginDto.TenDangNhap && nd.MatKhau == loginDto.MatKhau);

            if (nguoiDung == null)
            {
                return new AuthResponseDTO
                {
                    ThanhCong = false,
                    ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng.",
                    Token = null
                };
            }

            var token = GenerateJwtToken(nguoiDung);
            return new AuthResponseDTO
            {
                ThanhCong = true,
                ThongBao = "Đăng nhập thành công.",
                Token = token
            };
        }


        private string GenerateJwtToken(NguoiDung nguoiDung)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, nguoiDung.MaNV.ToString()),
            new Claim(ClaimTypes.Role, nguoiDung.MaVaiTro.ToString()) // Lưu role từ MaVaiTro
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Token hết hạn sau 1 giờ
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
    }
}
