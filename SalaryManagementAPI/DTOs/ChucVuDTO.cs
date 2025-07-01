namespace SalaryManagementAPI.DTOs
{
    public class ChucVuDTO
    {
        public int MaChucVu { get; set; }
        public string? TenChucVu { get; set; }
        [Precision(4, 2)]
        public decimal HeSoLuong { get; set; }
    }
}
