namespace SalaryManagementAPI.Models
{
    public class GiamTruThueTNCN
    {
        [Key]
        public int MaGiamTru { get; set; }

        public int MaNV { get; set; }

        public int Thang { get; set; }
        public int Nam { get; set; }

        [Required]
        [MaxLength(100)]
        public string LoaiGiamTru { get; set; } = null!; // "CaNhan", "PhuThuoc", "BHXH",...

        [Precision(15, 2)]
        public decimal SoTien { get; set; }

        public NhanVien? NhanVien { get; set; }

    }
}
