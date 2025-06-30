using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagementAPI.Models
{
    public class ChucVu
    {
        [Key]
        public int MaChucVu { get; set; }
        public string TenChucVu { get; set; } = null!;
        [Precision(4, 2)]
        public decimal HeSoLuong { get; set; }

        public ICollection<NhanVien>? NhanViens { get; set; }
    }

}
