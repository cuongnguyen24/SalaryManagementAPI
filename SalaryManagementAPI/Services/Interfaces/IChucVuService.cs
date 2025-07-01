namespace SalaryManagementAPI.Services.Interfaces
{
    public interface IChucVuService
    {
        Task<IEnumerable<ChucVuDTO>> GetAllAsync();
        Task<ChucVuDTO?> GetByIdAsync(int id);
        Task<ChucVuDTO> CreateAsync(ChucVuDTO cv);
        Task<bool> UpdateAsync(int id, ChucVuDTO cv);
        Task<bool> DeleteAsync(int id);
    }
}
