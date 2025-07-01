namespace SalaryManagementAPI.Services
{
    public class NhanVienService : INhanVienService
    {
        private readonly IRepository<NhanVien> _nhanVienRepo;
        private readonly IMapper _mapper;

        public NhanVienService(IRepository<NhanVien> nhanVienRepo, IMapper mapper)
        {
            _nhanVienRepo = nhanVienRepo;
            _mapper = mapper;
        }

        public async Task<NhanVienDTO> CreateAsync(NhanVienDTO nvDto)
        {
            // Dùng AutoMapper để chuyển DTO => Entity
            var nvEntity = _mapper.Map<NhanVien>(nvDto);
            await _nhanVienRepo.AddAsync(nvEntity);
            await _nhanVienRepo.SaveChangesAsync();

            // Sau khi thêm, có thể gán lại Id hoặc map lại nếu muốn
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
    }
}
