namespace SalaryManagementAPI.Services
{
    public class ChucVuService : IChucVuService
    {
        private readonly IRepository<ChucVu> _chucVuRepo;
        private readonly IMapper _mapper;

        public ChucVuService(IRepository<ChucVu> chucVuRepo, IMapper mapper)
        {
            _chucVuRepo = chucVuRepo;
            _mapper = mapper;
        }

        public async Task<ChucVuDTO> CreateAsync(ChucVuDTO dto)
        {
            var entity = _mapper.Map<ChucVu>(dto);
            await _chucVuRepo.AddAsync(entity);
            await _chucVuRepo.SaveChangesAsync();
            return _mapper.Map<ChucVuDTO>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _chucVuRepo.GetByIdAsync(id);
            if (existing == null) return false;

            _chucVuRepo.Delete(existing);
            await _chucVuRepo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ChucVuDTO>> GetAllAsync()
        {
            var list = await _chucVuRepo.GetAllAsync();
            return list.Select(cv => _mapper.Map<ChucVuDTO>(cv));
        }

        public async Task<ChucVuDTO?> GetByIdAsync(int id)
        {
            var entity = await _chucVuRepo.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<ChucVuDTO>(entity);
        }

        public async Task<bool> UpdateAsync(int id, ChucVuDTO dto)
        {
            var existing = await _chucVuRepo.GetByIdAsync(id);
            if (existing == null) return false;

            existing.TenChucVu = dto.TenChucVu;

            _chucVuRepo.Update(existing);
            await _chucVuRepo.SaveChangesAsync();
            return true;
        }
    }
}
