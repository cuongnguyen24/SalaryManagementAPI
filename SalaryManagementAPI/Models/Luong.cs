using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagementAPI.Models
{
    public class Luong
    {
        [Key]
        public int MaLuong { get; set; }
        public int MaNV { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        [Precision(15, 2)]
        public decimal TongLuong { get; set; }
        public int NgayTinhLuong { get; set; }

        public NhanVien? NhanVien { get; set; }
        public ChiTietLuong? ChiTietLuong { get; set; }
    }

}
