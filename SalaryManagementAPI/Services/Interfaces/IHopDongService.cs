namespace SalaryManagementAPI.Services.Interfaces
{
    public interface IHopDongService
    {
        Task<IEnumerable<HopDongDTO>> GetAllAsync();
        Task<HopDongDTO> GetByIdAsync(int maHD);
        Task<IEnumerable<HopDongDTO>> GetByNhanVienIdAsync(int maNV);
        Task<HopDongDTO> GetCurrentHopDongByNhanVienIdAsync(int maNV);
        Task<HopDongDTO> CreateAsync(HopDongDTO hopDongDto);
        Task<bool> UpdateAsync(int maHD, HopDongDTO hopDongDto);
        Task<bool> DeleteAsync(int maHD);
    }
}
