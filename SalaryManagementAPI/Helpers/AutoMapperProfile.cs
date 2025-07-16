namespace SalaryManagementAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GiamTruDTO, GiamTruThueTNCN>().ReverseMap();
            CreateMap<HopDong, HopDongDTO>().ReverseMap();
            //CreateMap<NhanVien, NhanVienDTO>().ReverseMap();
            CreateMap<NhanVien, NhanVienDTO>().ReverseMap()
            .ForMember(dest => dest.NgaySinh,
                opt => opt.MapFrom(src => DateTime.SpecifyKind(src.NgaySinh, DateTimeKind.Utc)));

            CreateMap<PhongBan, PhongBanDTO>().ReverseMap();
            CreateMap<ChucVu, ChucVuDTO>().ReverseMap();
            CreateMap<CapNhatThongTinCaNhanDTO, NhanVien>()
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
