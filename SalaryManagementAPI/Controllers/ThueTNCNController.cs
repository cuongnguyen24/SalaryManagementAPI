namespace SalaryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThueTNCNController : ControllerBase
    {
        private readonly IThueTNCNService _thueTNCNService;

        public ThueTNCNController(IThueTNCNService thueTNCNService)
        {
            _thueTNCNService = thueTNCNService;
        }

        // GET : api/ThueTNCN/nhanvien/{maNV}
        [HttpGet("nhanvien/{maNV}")]
        [Authorize(Roles = "1,2,3,5")]
        [SwaggerOperation(Summary = "Lấy danh sách thuế theo mã nhân viên")]
        public async Task<IActionResult> GetDanhSachThue(int maNV)
        {
            try
            {
                var result = await _thueTNCNService.LayDSThueNhanVienAsync(maNV);
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Lấy danh sách thuế thành công.",
                    DuLieu = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi lấy danh sách thuế: {ex.Message}"
                });
            }
        }

        // GET : api/ThueTNCN/nhanvien/{maNV}/thue
        [HttpGet("nhanvien/{maNV}/thue")]
        [Authorize(Roles = "1,2,3,5")]
        [SwaggerOperation(Summary = "Lấy thông tin thuế theo tháng/năm")]
        public async Task<IActionResult> GetThueTheoThang(int maNV, int thang, int nam)
        {
            try
            {
                var result = await _thueTNCNService.LayThongTinThueAsync(maNV, thang, nam);
                if (result == null)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = "Không tìm thấy thông tin thuế."
                    });
                }

                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Lấy thông tin thuế thành công.",
                    DuLieu = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi lấy thông tin thuế: {ex.Message}"
                });
            }
        }

        // POST : api/ThueTNCN/nhanvien/{maNV}/tinhthue
        [HttpPost("nhanvien/{maNV}/tinhthue")]
        [Authorize(Roles = "1,3")]
        [SwaggerOperation(Summary = "Tính thuế mới theo tháng")]
        public async Task<IActionResult> TinhThue(int maNV, int thang, int nam)
        {
            try
            {
                var result = await _thueTNCNService.TinhThueTheoThangAsync(maNV, thang, nam);
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Tính thuế thành công.",
                    DuLieu = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi tính thuế: {ex.Message}"
                });
            }
        }

        // GET : api/ThueTNCN/nhanvien/{maNV}/capnhatthue
        [HttpPut("nhanvien/{maNV}/capnhatthue")]
        [Authorize(Roles = "1,3")]
        [SwaggerOperation(Summary = "Cập nhật lại thuế (tính lại và cập nhật DB)")]
        public async Task<IActionResult> CapNhatThue(int maNV, int thang, int nam)
        {
            try
            {
                var result = await _thueTNCNService.CapNhatLaiThueAsync(maNV, thang, nam);
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Cập nhật thuế thành công.",
                    DuLieu = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi cập nhật thuế: {ex.Message}"
                });
            }
        }

        // GET : api/ThueTNCN/bangbac
        [HttpGet("bangbac")]
        [Authorize(Roles = "1,2,3,4,5")]
        [SwaggerOperation(Summary = "Lấy bảng bậc thuế")]
        public async Task<IActionResult> GetBangBacThue()
        {
            try
            {
                var result = await _thueTNCNService.LayBangBacThueAsync();
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Lấy bảng bậc thuế thành công.",
                    DuLieu = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi lấy bảng bậc thuế: {ex.Message}"
                });
            }
        }

        // GET : api/ThueTNCN/nhanvien/{maNV}/giamtru
        [HttpGet("nhanvien/{maNV}/giamtru")]
        [Authorize(Roles = "1,2,3,4,5")]
        [SwaggerOperation(Summary = "Lấy các khoản giảm trừ của nhân viên")]
        public async Task<IActionResult> GetGiamTru(int maNV, int thang, int nam)
        {
            try
            {
                var result = await _thueTNCNService.LayCacKhoanGiamTruAsync(maNV, thang, nam);
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Lấy khoản giảm trừ thành công.",
                    DuLieu = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi lấy khoản giảm trừ: {ex.Message}"
                });
            }
        }

        // POST: api/ThueTNCN/giamtru
        [HttpPost("giamtru")]
        [Authorize(Roles = "1,2,3")]
        [SwaggerOperation(Summary = "Thêm khoản giảm trừ cho nhân viên")]
        public async Task<IActionResult> ThemGiamTru([FromBody] GiamTruThueTNCN dto)
        {
            try
            {
                var created = await _thueTNCNService.ThemGiamTruAsync(dto);
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Thêm khoản giảm trừ thành công.",
                    DuLieu = created
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi thêm khoản giảm trừ: {ex.Message}"
                });
            }
        }

        // PUT: api/ThueTNCN/giamtru/{id}
        [HttpPut("giamtru/{id}")]
        [Authorize(Roles = "1,2,3")]
        [SwaggerOperation(Summary = "Cập nhật khoản giảm trừ theo ID")]
        public async Task<IActionResult> CapNhatGiamTru(int id, [FromBody] GiamTruThueTNCN dto)
        {
            try
            {
                var updated = await _thueTNCNService.CapNhatGiamTruAsync(id, dto);
                if (updated == null)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy khoản giảm trừ với ID {id}."
                    });
                }

                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Cập nhật khoản giảm trừ thành công.",
                    DuLieu = updated
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi cập nhật khoản giảm trừ: {ex.Message}"
                });
            }
        }

        // DELETE: api/ThueTNCN/giamtru/{id}
        [HttpDelete("giamtru/{id}")]
        [Authorize(Roles = "1,2,3")]
        [SwaggerOperation(Summary = "Xoá khoản giảm trừ theo ID")]
        public async Task<IActionResult> XoaGiamTru(int id)
        {
            try
            {
                var success = await _thueTNCNService.XoaGiamTruAsync(id);
                if (!success)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy khoản giảm trừ với ID {id}."
                    });
                }

                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Xoá khoản giảm trừ thành công."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi xoá khoản giảm trừ: {ex.Message}"
                });
            }
        }
    }
}
