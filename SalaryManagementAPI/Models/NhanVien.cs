namespace SalaryManagementAPI.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNV { get; set; }
        public string HoTen { get; set; } = null!;
        public string GioiTinh { get; set; } = null!;
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; } = null!;
        public string DienThoai { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int MaPhong { get; set; }
        public int MaChucVu { get; set; }

        public PhongBan? PhongBan { get; set; }
        public ChucVu? ChucVu { get; set; }

        public ICollection<Luong>? Luongs { get; set; }
        public ICollection<BaoHiem>? BaoHiems { get; set; }
        public ICollection<ThueTNCN>? ThueTNCNs { get; set; }
        public ICollection<HopDong>? HopDongs { get; set; }
        public ICollection<ChamCong>? ChamCongs { get; set; }
        public ICollection<PhuCap>? PhuCaps { get; set; }
        public ICollection<ThuongPhat>? ThuongPhats { get; set; }
        public ICollection<NguoiDung>? NguoiDungs { get; set; }
        public ICollection<GiamTruThueTNCN>? GiamTruThueTNCNs { get; set; }

    }

}
