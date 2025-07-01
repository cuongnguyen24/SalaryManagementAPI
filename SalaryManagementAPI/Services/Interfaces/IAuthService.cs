namespace SalaryManagementAPI.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Kiểm tra đăng nhập và trả về JWT token nếu hợp lệ
        /// </summary>
        /// <param name="loginDto">Thông tin đăng nhập</param>
        /// <returns>JWT token hoặc null nếu thất bại</returns>
        Task<AuthResponseDTO> LoginAsync(LoginRequestDTO loginDto);
    }
}
