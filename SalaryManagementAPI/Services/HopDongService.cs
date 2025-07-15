
using SalaryManagementAPI.Models;

namespace SalaryManagementAPI.Services
{
    public class HopDongService : IHopDongService
    {
        private readonly IRepository<HopDong> _hopDongRepo;
        private readonly IRepository<NhanVien> _nhanVienRepo;
        private readonly IMapper _mapper;

        public HopDongService(IRepository<HopDong> hopDongRepo, IRepository<NhanVien> nhanVienRepo, IMapper mapper)
        {
            _hopDongRepo = hopDongRepo;
            _nhanVienRepo = nhanVienRepo;
            _mapper = mapper;
        }

        // Thêm mới hợp đồng
        public async Task<HopDongDTO> CreateAsync(HopDongDTO hopDongDto)
        {
            var nv = await _hopDongRepo.GetByIdAsync(hopDongDto.MaNV);
            if (nv == null)
                throw new Exception($"Không tìm thấy nhân viên với mã {hopDongDto.MaNV}");

            var hopDong = _mapper.Map<HopDong>(hopDongDto);
            await _hopDongRepo.AddAsync(hopDong);
            await _hopDongRepo.SaveChangesAsync();

            return _mapper.Map<HopDongDTO>(hopDong);
        }

        // Xóa hợp đồng
        public async Task<bool> DeleteAsync(int maHD)
        {
            var existing = await _hopDongRepo.GetByIdAsync(maHD);
            if (existing == null) return false;

            _hopDongRepo.Delete(existing);
            await _hopDongRepo.SaveChangesAsync();
            return true;
        }

        // 	Lấy danh sách tất cả hợp đồng
        public async Task<IEnumerable<HopDongDTO>> GetAllAsync()
        {
            var hopDongs = await _hopDongRepo.GetAllAsync();
            return hopDongs.Select(hd => _mapper.Map<HopDongDTO>(hd));
        }

        // Lấy hợp đồng theo mã hợp đồng
        public async Task<HopDongDTO?> GetByIdAsync(int maHD)
        {
            var hopDong = await _hopDongRepo.GetByIdAsync(maHD);
            return hopDong == null ? null : _mapper.Map<HopDongDTO>(hopDong);
        }

        //	Lấy tất cả hợp đồng của một nhân viên
        public async Task<IEnumerable<HopDongDTO>> GetByNhanVienIdAsync(int maNV)
        {
            var dsHopDong = await _hopDongRepo.FindAsync(hd => hd.MaNV ==  maNV);
            return dsHopDong.Select(hd => _mapper.Map<HopDongDTO>(hd));
        }

        // 	Lấy hợp đồng đang hiệu lực hiện tại (dùng trong tính lương)
        public async Task<HopDongDTO?> GetCurrentHopDongByNhanVienIdAsync(int maNV)
        {
            var currentHopDong = (await _hopDongRepo.FindAsync(hd =>
                hd.MaNV == maNV &&
                hd.NgayBatDau <= DateTime.Now &&
                (hd.NgayKetThuc == null || hd.NgayKetThuc >= DateTime.Now)))
                .OrderByDescending(hd => hd.NgayBatDau)
                .FirstOrDefault();

            return currentHopDong == null ? null : _mapper.Map<HopDongDTO>(currentHopDong);
        }

        // 	Cập nhật hợp đồng theo mã
        public async Task<bool> UpdateAsync(int maHD, HopDongDTO hopDongDto)
        {
            var existing = await _hopDongRepo.GetByIdAsync(maHD);
            if (existing == null) return false;

            _mapper.Map(hopDongDto, existing);
            _hopDongRepo.Update(existing);
            await _hopDongRepo.SaveChangesAsync();
            return true;
        }
    }
}
