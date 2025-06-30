using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagementAPI.Models
{
    public class ChiTietLuong
    {
        [Key]
        public int MaChiTiet { get; set; }
        public int MaLuong { get; set; }

        [Precision(15, 2)]
        public decimal LuongCoBan { get; set; }
        [Precision(4, 2)]
        public decimal HeSoLuong { get; set; }
        [Precision(15, 2)]
        public decimal TongPhuCap { get; set; }
        [Precision(15, 2)]
        public decimal TongThuong { get; set; }
        [Precision(15, 2)]
        public decimal TongPhat { get; set; }
        [Precision(15, 2)]
        public decimal LuongTruocKhauTru { get; set; }
        [Precision(15, 2)]
        public decimal LuongThucLanh { get; set; }

        public Luong? Luong { get; set; }
    }

}
