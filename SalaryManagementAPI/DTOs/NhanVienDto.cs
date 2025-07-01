namespace SalaryManagementAPI.DTOs
{
    public class NhanVienDTO
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string? GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }

        public string? TenPhongBan { get; set; }
        public string? TenChucVu { get; set; }
    }
}
