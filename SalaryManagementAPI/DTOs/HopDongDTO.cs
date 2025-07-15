namespace SalaryManagementAPI.DTOs
{
    public class HopDongDTO
    {
        public int MaHD { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string LoaiHopDong { get; set; }
        public decimal MucLuongCoBan { get; set; }
    }
}
