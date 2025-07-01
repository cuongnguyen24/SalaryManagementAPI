namespace SalaryManagementAPI.Services.Interfaces
{
    public interface INhanVienService
    {
        Task<IEnumerable<NhanVienDTO>> GetAllAsync();
        Task<NhanVienDTO?> GetByIdAsync(int id);
        Task<NhanVienDTO> CreateAsync(NhanVienDTO nv);
        Task<bool> UpdateAsync(int id, NhanVienDTO nv);
        Task<bool> DeleteAsync(int id);
    }
}
