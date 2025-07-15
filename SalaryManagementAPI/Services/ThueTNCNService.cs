
namespace SalaryManagementAPI.Services
{
    public class ThueTNCNService : IThueTNCNService
    {
        private readonly AppDbContext _context;

        public ThueTNCNService(AppDbContext context)
        {
            _context = context;
        }

        // Cập nhật khoản giảm trừ
        public async Task<GiamTruThueTNCN?> CapNhatGiamTruAsync(int id, GiamTruThueTNCN giamTru)
        {
            var existing = await _context.GiamTruThueTNCNs.FindAsync(id);
            if (existing == null)
                return null;

            // Cập nhật các trường
            existing.Thang = giamTru.Thang;
            existing.Nam = giamTru.Nam;
            existing.LoaiGiamTru = giamTru.LoaiGiamTru;
            existing.SoTien = giamTru.SoTien;
            existing.MaNV = giamTru.MaNV;

            await _context.SaveChangesAsync();
            return existing;
        }

        // Tính lại thuế (khi có thay đổi lương, giảm trừ...)
        public async Task<ThueTNCN> CapNhatLaiThueAsync(int maNV, int thang, int nam)
        {
            var thue = await TinhThueTheoThangAsync(maNV, thang, nam);

            var daTonTai = await _context.ThuTNCNs
                .FirstOrDefaultAsync(t => t.MaNV == maNV && t.Thang == thang && t.Nam == nam);

            if (daTonTai != null)
            {
                daTonTai.ThuNhapChiuThue = thue.ThuNhapChiuThue;
                daTonTai.ThuePhaiDong = thue.ThuePhaiDong;
                daTonTai.BacThue = thue.BacThue;
                daTonTai.NgayTinhThue = DateTime.Now;
            }
            else
            {
                await _context.ThuTNCNs.AddAsync(thue);
            }

            await _context.SaveChangesAsync();
            return thue;
        }

        // Lấy bảng bậc thuế (7 bậc lũy tiến)
        public async Task<IEnumerable<BangThueTNCN>> LayBangBacThueAsync()
        {
            return await _context.BangThueTNCNs.OrderBy(b => b.Bac).ToListAsync();
        }

        // Lấy danh sách giảm trừ của một nhân viên trong tháng/năm
        public async Task<IEnumerable<GiamTruThueTNCN>> LayCacKhoanGiamTruAsync(int maNV, int thang, int nam)
        {
            return await _context.GiamTruThueTNCNs
                .Where(gt => gt.MaNV == maNV && gt.Thang == thang && gt.Nam == nam)
                .ToListAsync();
        }

        // Lấy danh sách thuế đã tính cho 1 nhân viên
        public async Task<IEnumerable<ThueTNCN>> LayDSThueNhanVienAsync(int maNV)
        {
            return await _context.ThuTNCNs
                .Where(t => t.MaNV == maNV)
                .Include(t => t.BacThueInfo)
                .OrderByDescending(t => t.Nam).ThenByDescending(t => t.Thang)
                .ToListAsync();
        }

        // Lấy thông tin thuế của 1 nhân viên theo tháng/năm cụ thể
        public async Task<ThueTNCN?> LayThongTinThueAsync(int maNV, int thang, int nam)
        {
            return await _context.ThuTNCNs
                .Include(t => t.BacThueInfo)
                .FirstOrDefaultAsync(t => t.MaNV == maNV && t.Thang == thang && t.Nam == nam);
        }

        // Thêm khoản giảm trừ
        public async Task<GiamTruThueTNCN> ThemGiamTruAsync(GiamTruThueTNCN giamTru)
        {
            await _context.GiamTruThueTNCNs.AddAsync(giamTru);
            await _context.SaveChangesAsync();
            return giamTru;
        }

        // Tính thuế cho một nhân viên theo tháng/năm
        public async Task<ThueTNCN> TinhThueTheoThangAsync(int maNV, int thang, int nam)
        {
            var luong = await _context.Luongs
                .Where(l => l.MaNV == maNV && l.Thang == thang && l.Nam == nam)
                .FirstOrDefaultAsync();

            if (luong == null)
                throw new Exception("Không tìm thấy lương tháng này.");

            var tongLuong = luong.TongLuong;
            var cacGiamTru = await LayCacKhoanGiamTruAsync(maNV, thang, nam);
            var tongGiamTru = cacGiamTru.Sum(gt => gt.SoTien);
            var thuNhapTinhThue = tongLuong - tongGiamTru;

            var bac = await _context.BangThueTNCNs
                .OrderBy(b => b.Bac)
                .FirstOrDefaultAsync(b =>
                    (!b.MucTu.HasValue || thuNhapTinhThue >= b.MucTu) &&
                    (!b.MucDen.HasValue || thuNhapTinhThue <= b.MucDen));

            if (bac == null)
                throw new Exception("Không xác định được bậc thuế.");

            var thue = (thuNhapTinhThue * bac.TyLe) - bac.SoTienGiamTru;
            if (thue < 0) thue = 0;

            var thueTNCN = new ThueTNCN
            {
                MaNV = maNV,
                Thang = thang,
                Nam = nam,
                ThuNhapChiuThue = thuNhapTinhThue,
                ThuePhaiDong = thue,
                BacThue = bac.Bac,
                NgayTinhThue = DateTime.Now
            };

            return thueTNCN;
        }

        // Xoá khoản giảm trừ
        public async Task<bool> XoaGiamTruAsync(int id)
        {
            var giamTru = await _context.GiamTruThueTNCNs.FindAsync(id);
            if (giamTru == null)
                return false;

            _context.GiamTruThueTNCNs.Remove(giamTru);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
