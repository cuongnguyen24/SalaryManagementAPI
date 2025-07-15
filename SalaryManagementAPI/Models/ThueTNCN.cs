using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryManagementAPI.Models
{
    public class ThueTNCN
    {
        [Key]
        public int MaThue { get; set; }
        public int MaNV { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        [Precision(15, 2)]
        public decimal ThuNhapChiuThue { get; set; }
        [Precision(15, 2)]
        public decimal ThuePhaiDong { get; set; }

        public NhanVien? NhanVien { get; set; }

        public int BacThue { get; set; }

        [ForeignKey("BacThue")]
        public BangThueTNCN? BacThueInfo { get; set; }

        public DateTime NgayTinhThue { get; set; } = DateTime.Now;
    }
}
