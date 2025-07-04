namespace SalaryManagementAPI.DTOs
{
    public class CapNhatThongTinCaNhanDTO
    {
        [MaxLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự.")]
        public string? HoTen { get; set; }

        [RegularExpression("^(Nam|Nữ)?$", ErrorMessage = "Giới tính phải là 'Nam' hoặc 'Nữ'.")]
        public string? GioiTinh { get; set; }

        [DataType(DataType.Date)]
        [CustomDateInPast(ErrorMessage = "Ngày sinh không được lớn hơn ngày hiện tại.")]
        public DateTime? NgaySinh { get; set; }

        [MaxLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự.")]
        public string? DiaChi { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại phải gồm 10–11 chữ số.")]
        public string? DienThoai { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string? Email { get; set; }
    }
}
