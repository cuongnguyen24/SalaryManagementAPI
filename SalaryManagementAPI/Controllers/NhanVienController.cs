namespace SalaryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;

        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }

        // GET: api/NhanVien
        [HttpGet]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Lấy danh sách nhân viên")]
        public async Task<ActionResult<IEnumerable<NhanVienDTO>>> GetAll()
        {
            try
            {
                var danhSach = await _nhanVienService.GetAllAsync();
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Lấy danh sách nhân viên thành công.",
                    DuLieu = danhSach
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi lấy danh sách nhân viên: {ex.Message}",
                });
            }
        }

        // GET: api/NhanVien/5
        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Tìm nhân viên theo id")]
        public async Task<ActionResult<NhanVienDTO>> GetById(int id)
        {
            try
            {
                var nhanVien = await _nhanVienService.GetByIdAsync(id);
                if (nhanVien == null)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy nhân viên với ID {id}.",
                    });
                }
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = $"Lấy nhân viên với ID {id} thành công.",
                    DuLieu = nhanVien
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi lấy nhân viên: {ex.Message}",
                });
            }
        }

        // GET: api/NhanVien/phongban/3
        [HttpGet("phongban/{maPhongBan}")]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Lấy danh sách nhân viên theo phòng ban")]
        public async Task<IActionResult> GetByPhongBan(int maPhongBan)
        {
            try
            {
                var ds = await _nhanVienService.GetByPhongBanAsync(maPhongBan);

                if (ds == null || !ds.Any())
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không có nhân viên nào thuộc phòng ban có mã {maPhongBan}."
                    });
                }

                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = $"Lấy danh sách nhân viên phòng ban {maPhongBan} thành công.",
                    DuLieu = ds
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi lấy nhân viên theo phòng ban: {ex.Message}",
                });
            }
        }

        // POST: api/NhanVien
        [HttpPost]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Thêm nhân viên")]
        public async Task<ActionResult<NhanVienDTO>> Create([FromBody] NhanVienDTO nvDto)
        {
            try
            {
                var created = await _nhanVienService.CreateAsync(nvDto);
                return CreatedAtAction(nameof(GetById), new { id = created.MaNV }, new
                {
                    ThanhCong = true,
                    ThongBao = "Tạo nhân viên thành công.",
                    DuLieu = created
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi tạo nhân viên: {ex.Message}",
                });
            }
        }

        // PUT: api/NhanVien/5
        [HttpPut("{id}")]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Cập nhật nhân viên")]
        public async Task<IActionResult> Update(int id, [FromBody] NhanVienDTO nvDto)
        {
            try
            {
                var result = await _nhanVienService.UpdateAsync(id, nvDto);
                if (!result)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy nhân viên với ID {id}.",
                    });
                }
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = $"Cập nhật nhân viên với ID {id} thành công.",
                    DuLieu = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi cập nhật nhân viên: {ex.Message}",
                });
            }
        }

        // DELETE: api/NhanVien/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Xóa nhân viên")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _nhanVienService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy nhân viên với ID {id}.",
                    });
                }
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = $"Xóa nhân viên với ID {id} thành công.",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi xóa nhân viên: {ex.Message}",
                });
            }
        }

        [HttpGet("me")]
        [Authorize]
        [SwaggerOperation(Summary = "Lấy thông tin cá nhân của người dùng hiện tại")]
        public async Task<IActionResult> GetMyProfile()
        {
            var maNv = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(maNv))
                return Unauthorized(new { ThanhCong = false, ThongBao = "Không xác định được người dùng." });

            var nv = await _nhanVienService.GetByIdAsync(int.Parse(maNv));
            if (nv == null)
                return NotFound(new { ThanhCong = false, ThongBao = "Không tìm thấy thông tin cá nhân." });

            return Ok(new
            {
                ThanhCong = true,
                ThongBao = "Lấy thông tin cá nhân thành công.",
                DuLieu = nv
            });
        }

        [HttpPut("me")]
        [Authorize]
        [SwaggerOperation(Summary = "Cập nhật thông tin cá nhân")]
        public async Task<IActionResult> CapNhatThongTinCaNhan([FromBody] CapNhatThongTinCaNhanDTO dto)
        {
            try
            {
                var maNvStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(maNvStr) || !int.TryParse(maNvStr, out int maNv))
                {
                    return Unauthorized(new
                    {
                        ThanhCong = false,
                        ThongBao = "Không xác định được người dùng."
                    });
                }

                var updatedNhanVien = await _nhanVienService.CapNhatThongTinCaNhanAsync(maNv, dto);
                if (updatedNhanVien == null)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy nhân viên có mã {maNv}."
                    });
                }

                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Cập nhật thông tin cá nhân thành công.",
                    DuLieu = updatedNhanVien
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi cập nhật thông tin cá nhân: {ex.Message}"
                });
            }
        }

        // PUT: api/NhanVien/5/phongban
        [HttpPut("{id}/phongban")]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Cập nhật phòng ban cho nhân viên")]
        public async Task<IActionResult> CapNhatPhongBan(int id, [FromBody] int maPhongBanMoi)
        {
            try
            {
                var updated = await _nhanVienService.CapNhatPhongBanAsync(id, maPhongBanMoi);
                if (updated == null)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy nhân viên có ID {id}."
                    });
                }

                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Cập nhật phòng ban cho nhân viên thành công.",
                    DuLieu = updated
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi cập nhật phòng ban: {ex.Message}"
                });
            }
        }

        // PUT: api/NhanVien/5/chucvu
        [HttpPut("{id}/chucvu")]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Cập nhật chức vụ cho nhân viên")]
        public async Task<IActionResult> CapNhatChucVu(int id, [FromBody] int maChucVuMoi)
        {
            try
            {
                var updated = await _nhanVienService.CapNhatChucVuAsync(id, maChucVuMoi);
                if (updated == null)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy nhân viên có ID {id}."
                    });
                }

                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Cập nhật chức vụ cho nhân viên thành công.",
                    DuLieu = updated
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi cập nhật chức vụ: {ex.Message}"
                });
            }
        }

    }
}
