namespace SalaryManagementAPI.DTOs
{
    public class AuthResponseDTO
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; } = string.Empty;
        public string? Token { get; set; }
    }
}
