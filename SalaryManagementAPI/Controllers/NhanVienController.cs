using Swashbuckle.AspNetCore.Annotations;

namespace SalaryManagementAPI.Controllers
{
    [Authorize(Roles = "1,2")]
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
    }
}
