namespace SalaryManagementAPI.Models
{
    public class BangThueTNCN
    {
        [Key]
        public int Bac { get; set; } // 1 -> 7

        public decimal? MucTu { get; set; }     // Thu nhập từ (có thể null nếu là 0)
        public decimal? MucDen { get; set; }    // Thu nhập đến (null nếu là vô hạn)

        [Precision(5, 2)]
        public decimal TyLe { get; set; }       // VD: 0.05 (5%)

        [Precision(15, 2)]
        public decimal SoTienGiamTru { get; set; }

        [Required]
        public DateTime ThoiGianHieuLuc { get; set; } // Ngày bắt đầu áp dụng

        public ICollection<ThueTNCN>? ThueTNCNs { get; set; }
    }
}
