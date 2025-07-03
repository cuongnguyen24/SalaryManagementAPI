

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

        public async Task<(bool ThanhCong, string ThongBao)> CapTaiKhoanAsync(CapTaiKhoanDTO dto)
        {
            var nhanVien = await _context.NhanViens.FindAsync(dto.MaNhanVien);
            if (nhanVien == null)
                return (false, "Không tìm thấy nhân viên.");

            var daCo = await _context.NguoiDungs.AnyAsync(x => x.MaNV == dto.MaNhanVien);
            if (daCo)
                return (false, "Nhân viên này đã có tài khoản.");

            var nguoiDung = new NguoiDung
            {
                TenDangNhap = dto.TenDangNhap,
                MatKhau = BCrypt.Net.BCrypt.HashPassword(dto.MatKhau),
                MaNV = dto.MaNhanVien,
                MaVaiTro = dto.MaVaiTro
            };

            _context.NguoiDungs.Add(nguoiDung);
            await _context.SaveChangesAsync();

            return (true, "Cấp tài khoản thành công.");
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginRequestDTO loginDto)
        {
            var nguoiDung = await _context.NguoiDungs
                .FirstOrDefaultAsync(nd => nd.TenDangNhap == loginDto.TenDangNhap);

            if (nguoiDung == null)
            {
                return new AuthResponseDTO
                {
                    ThanhCong = false,
                    ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng.",
                    Token = null
                };
            }

            // So sánh mật khẩu đã hash
            bool matKhauDung = BCrypt.Net.BCrypt.Verify(loginDto.MatKhau, nguoiDung.MatKhau);
            if (!matKhauDung)
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

        public async Task<(bool ThanhCong, string ThongBao)> DoiMatKhauAsync(string maNv, DoiMatKhauDTO dto)
        {
            var nguoiDung = await _context.NguoiDungs.FirstOrDefaultAsync(nd => nd.MaNV.ToString() == maNv);

            if (nguoiDung == null)
                return (false, "Không tìm thấy người dùng.");

            bool matKhauCuDung = BCrypt.Net.BCrypt.Verify(dto.MatKhauCu, nguoiDung.MatKhau);
            if (!matKhauCuDung)
                return (false, "Mật khẩu cũ không đúng.");

            nguoiDung.MatKhau = BCrypt.Net.BCrypt.HashPassword(dto.MatKhauMoi);
            _context.NguoiDungs.Update(nguoiDung);
            await _context.SaveChangesAsync();

            return (true, "Đổi mật khẩu thành công.");
        }


    }
}
