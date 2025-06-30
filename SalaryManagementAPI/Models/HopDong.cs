using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagementAPI.Models
{
    public class HopDong
    {
        [Key]
        public int MaHD { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string LoaiHopDong { get; set; } = null!;
        [Precision(15, 2)]
        public decimal MucLuongCoBan { get; set; }

        public NhanVien? NhanVien { get; set; }
    }
}
