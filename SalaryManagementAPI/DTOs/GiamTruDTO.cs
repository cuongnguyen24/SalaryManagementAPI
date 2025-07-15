namespace SalaryManagementAPI.DTOs
{
    public class GiamTruDTO
    {
        public int MaNV { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string LoaiGiamTru { get; set; } = string.Empty;
        public decimal SoTien { get; set; }
    }
}
