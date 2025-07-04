namespace SalaryManagementAPI.DTOs
{
    public class NhanVienDTO
    {
        public int MaNV { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống.")]
        [MaxLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự.")]
        public string HoTen { get; set; } = string.Empty;

        [RegularExpression("^(Nam|Nữ)?$", ErrorMessage = "Giới tính phải là 'Nam', 'Nữ'")]
        public string? GioiTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh.")]
        [DataType(DataType.Date)]
        [CustomDateInPast(ErrorMessage = "Ngày sinh không được lớn hơn ngày hiện tại.")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
        [MaxLength(200)]
        public string? DiaChi { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại phải gồm 10–11 chữ số.")]
        public string? DienThoai { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phòng ban không được để trống.")]
        public string? MaPhong { get; set; }

        [Required(ErrorMessage = "Chức vụ không được để trống.")]
        public string? MaChucVu { get; set; }
    }
}
