namespace SalaryManagementAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NhanVien, NhanVienDTO>().ReverseMap();
            CreateMap<PhongBan, PhongBanDTO>().ReverseMap();
            CreateMap<ChucVu, ChucVuDTO>().ReverseMap();
        }
    }
}
