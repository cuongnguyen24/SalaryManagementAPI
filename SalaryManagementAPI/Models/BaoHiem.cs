using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagementAPI.Models
{
    public class BaoHiem
    {
        [Key]
        public int MaBH { get; set; }
        public int MaNV { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }

        [Precision(15, 2)]
        public decimal BHXH { get; set; }
        [Precision(15, 2)]
        public decimal BHYT { get; set; }
        [Precision(15, 2)]
        public decimal BHTN { get; set; }
        [Precision(15, 2)]
        public decimal TongBH { get; set; }

        public NhanVien? NhanVien { get; set; }
    }

}
