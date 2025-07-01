namespace SalaryManagementAPI.Models
{
    public class ThuongPhat
    {
        [Key]
        public int MaTP { get; set; }
        public int MaNV { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }

        public string Loai { get; set; } = null!;
        public string LyDo { get; set; } = null!;
        [Precision(15, 2)]
        public decimal SoTien { get; set; }

        public NhanVien? NhanVien { get; set; }
    }

}
