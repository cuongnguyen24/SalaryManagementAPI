namespace SalaryManagementAPI.Models
{
    public class PhongBan
    {
        [Key]
        public int MaPhong { get; set; }
        public string TenPhong { get; set; } = null!;

        public ICollection<NhanVien>? NhanViens { get; set; }
    }

}
