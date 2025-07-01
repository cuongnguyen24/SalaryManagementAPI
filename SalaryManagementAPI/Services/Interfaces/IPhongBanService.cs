namespace SalaryManagementAPI.Services.Interfaces
{
    public interface IPhongBanService
    {
        Task<IEnumerable<PhongBanDTO>> GetAllAsync();
        Task<PhongBanDTO?> GetByIdAsync(int id);
        Task<PhongBanDTO> CreateAsync(PhongBanDTO pb);
        Task<bool> UpdateAsync(int id, PhongBanDTO pb);
        Task<bool> DeleteAsync(int id);
    }
}
