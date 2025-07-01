namespace SalaryManagementAPI.Services
{
    public class PhongBanService : IPhongBanService
    {
        private readonly IRepository<PhongBan> _repo;
        private readonly IMapper _mapper;

        public PhongBanService(IRepository<PhongBan> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PhongBanDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(p => _mapper.Map<PhongBanDTO>(p));
        }

        public async Task<PhongBanDTO?> GetByIdAsync(int id)
        {
            var pb = await _repo.GetByIdAsync(id);
            return pb == null ? null : _mapper.Map<PhongBanDTO>(pb);
        }

        public async Task<PhongBanDTO> CreateAsync(PhongBanDTO pbDto)
        {
            var pb = _mapper.Map<PhongBan>(pbDto);
            await _repo.AddAsync(pb);
            await _repo.SaveChangesAsync();
            return _mapper.Map<PhongBanDTO>(pb);
        }

        public async Task<bool> UpdateAsync(int id, PhongBanDTO pbDto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            existing.TenPhong = pbDto.TenPhong;
            _repo.Update(existing);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pb = await _repo.GetByIdAsync(id);
            if (pb == null) return false;

            _repo.Delete(pb);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
