namespace SalaryManagementAPI.Models
{
    public class NguoiDung
    {
        public string TenDangNhap { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public int MaNV { get; set; }
        public int MaVaiTro { get; set; }

        public NhanVien? NhanVien { get; set; }
        public VaiTro? VaiTro { get; set; }
    }

}
