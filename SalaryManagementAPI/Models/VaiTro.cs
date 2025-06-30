using System.ComponentModel.DataAnnotations;

namespace SalaryManagementAPI.Models
{
    public class VaiTro
    {
        [Key]
        public int MaVaiTro { get; set; }
        public string TenVaiTro { get; set; } = null!;

        public ICollection<NguoiDung>? NguoiDungs { get; set; }
    }

}
