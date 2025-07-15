namespace SalaryManagementAPI.Services.Interfaces
{
    public interface IThueTNCNService
    {
        // 1. Tính thuế cho một nhân viên theo tháng/năm
        Task<ThueTNCN> TinhThueTheoThangAsync(int maNV, int thang, int nam);

        // 2. Lấy danh sách thuế đã tính cho 1 nhân viên
        Task<IEnumerable<ThueTNCN>> LayDSThueNhanVienAsync(int maNV);

        // 3. Lấy thông tin thuế của 1 nhân viên theo tháng/năm cụ thể
        Task<ThueTNCN?> LayThongTinThueAsync(int maNV, int thang, int nam);

        // 4. Tính lại thuế (khi có thay đổi lương, giảm trừ...)
        Task<ThueTNCN> CapNhatLaiThueAsync(int maNV, int thang, int nam);

        // 5. Lấy bảng bậc thuế (7 bậc lũy tiến)
        Task<IEnumerable<BangThueTNCN>> LayBangBacThueAsync();

        // 6. Lấy danh sách giảm trừ của một nhân viên trong tháng/năm
        Task<IEnumerable<GiamTruThueTNCN>> LayCacKhoanGiamTruAsync(int maNV, int thang, int nam);

        // 7. Thêm khoản giảm trừ
        Task<GiamTruThueTNCN> ThemGiamTruAsync(GiamTruThueTNCN giamTru);

        // 8. Cập nhật khoản giảm trừ
        Task<GiamTruThueTNCN?> CapNhatGiamTruAsync(int id, GiamTruThueTNCN giamTru);

        // 9. Xoá khoản giảm trừ
        Task<bool> XoaGiamTruAsync(int id);
    }
}
