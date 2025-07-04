namespace SalaryManagementAPI.DTOs
{
    public class PhongBanDTO
    {
        public int MaPhong { get; set; }

        [Required(ErrorMessage = "Tên phòng không được để trống.")]
        [MaxLength(100, ErrorMessage = "Tên phòng không được vượt quá 100 ký tự.")]
        public string? TenPhong { get; set; }
    }
}
