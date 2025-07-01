namespace SalaryManagementAPI.Models
{
    public class ChamCong
    {
        [Key]
        public int MaCC { get; set; }
        public int MaNV { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }

        public int SoNgayCong { get; set; }
        public int SoGioTangCa { get; set; }
        public int SoNgayNghiCoPhep { get; set; }
        public int SoNgayNghiKhongPhep { get; set; }

        public NhanVien? NhanVien { get; set; }
    }

}
