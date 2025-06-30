using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
    }
}
