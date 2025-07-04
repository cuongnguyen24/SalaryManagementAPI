using SalaryManagementAPI.Models;

namespace SalaryManagementAPI.Services
{
    public class NhanVienService : INhanVienService
    {
        private readonly IRepository<NhanVien> _nhanVienRepo;
        private readonly IRepository<PhongBan> _phongBanRepo;
        private readonly IRepository<ChucVu> _chucVuRepo;
        private readonly IMapper _mapper;

        public NhanVienService(IRepository<NhanVien> nhanVienRepo, IRepository<PhongBan> phongBanRepo, IRepository<ChucVu> chucVuRepo, IMapper mapper)
        {
            _nhanVienRepo = nhanVienRepo;
            _phongBanRepo = phongBanRepo;
            _chucVuRepo = chucVuRepo;
            _mapper = mapper;
        }

        public async Task<NhanVienDTO?> CapNhatThongTinCaNhanAsync(int maNv, CapNhatThongTinCaNhanDTO dto)
        {
            var nv = await _nhanVienRepo.GetByIdAsync(maNv);
            if (nv == null) return null;

            _mapper.Map(dto, nv);

            _nhanVienRepo.Update(nv);
            await _nhanVienRepo.SaveChangesAsync();

            return _mapper.Map<NhanVienDTO>(nv);
        }

        public async Task<NhanVienDTO> CreateAsync(NhanVienDTO nvDto)
        {
            // Dùng AutoMapper để chuyển DTO => Entity
            var nvEntity = _mapper.Map<NhanVien>(nvDto);
            await _nhanVienRepo.AddAsync(nvEntity);
            await _nhanVienRepo.SaveChangesAsync();

            return _mapper.Map<NhanVienDTO>(nvEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var nv = await _nhanVienRepo.GetByIdAsync(id);
            if (nv == null) return false;

            _nhanVienRepo.Delete(nv);
            await _nhanVienRepo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<NhanVienDTO>> GetAllAsync()
        {
            var nhanViens = await _nhanVienRepo.GetAllAsync();
            return nhanViens.Select(nv => _mapper.Map<NhanVienDTO>(nv));
        }

        public async Task<NhanVienDTO?> GetByIdAsync(int id)
        {
            var nv = await _nhanVienRepo.GetByIdAsync(id);
            return nv == null ? null : _mapper.Map<NhanVienDTO>(nv);
        }

        public async Task<IEnumerable<NhanVienDTO>> GetByPhongBanAsync(int maPhong)
        {
            var dsNhanVien = await _nhanVienRepo
                .FindAsync(nv => nv.MaPhong == maPhong);

            return dsNhanVien.Select(nv => _mapper.Map<NhanVienDTO>(nv));
        }

        public async Task<bool> UpdateAsync(int id, NhanVienDTO nvDto)
        {
            var existing = await _nhanVienRepo.GetByIdAsync(id);
            if (existing == null) return false;

            // Cập nhật dữ liệu từ DTO vào Entity
            _mapper.Map(nvDto, existing);

            _nhanVienRepo.Update(existing);
            await _nhanVienRepo.SaveChangesAsync();
            return true;
        }

        public async Task<NhanVienDTO?> CapNhatPhongBanAsync(int maNv, int maPhongBanMoi)
        {
            var nv = await _nhanVienRepo.GetByIdAsync(maNv);
            if (nv == null) return null;

            // Kiểm tra phòng ban có tồn tại không
            var phongBan = await _phongBanRepo.GetByIdAsync(maPhongBanMoi);
            if (phongBan == null) throw new Exception($"Phòng ban với mã {maPhongBanMoi} không tồn tại.");

            nv.MaPhong = maPhongBanMoi;
            _nhanVienRepo.Update(nv);
            await _nhanVienRepo.SaveChangesAsync();

            return _mapper.Map<NhanVienDTO>(nv);
        }

        public async Task<NhanVienDTO?> CapNhatChucVuAsync(int maNv, int maChucVuMoi)
        {
            var nv = await _nhanVienRepo.GetByIdAsync(maNv);
            if (nv == null) return null;

            // Kiểm tra chức vụ có tồn tại không
            var chucVu = await _chucVuRepo.GetByIdAsync(maChucVuMoi);
            if (chucVu == null) throw new Exception($"Chức vụ với mã {maChucVuMoi} không tồn tại.");

            nv.MaChucVu = maChucVuMoi;
            _nhanVienRepo.Update(nv);
            await _nhanVienRepo.SaveChangesAsync();

            return _mapper.Map<NhanVienDTO>(nv);
        }


    }
}
