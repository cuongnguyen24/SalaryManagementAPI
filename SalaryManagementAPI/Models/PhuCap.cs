namespace SalaryManagementAPI.Models
{
    public class PhuCap
    {
        [Key]
        public int MaPC { get; set; }
        public int MaNV { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }

        public string LoaiPhuCap { get; set; } = null!;
        [Precision(15, 2)]
        public decimal SoTien { get; set; }

        public NhanVien? NhanVien { get; set; }
    }

}
