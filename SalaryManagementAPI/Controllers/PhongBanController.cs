using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SalaryManagementAPI.Controllers
{
    [Authorize(Roles = "1")]
    [Route("api/[controller]")]
    [ApiController]
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanService _phongBanService;

        public PhongBanController(IPhongBanService phongBanService)
        {
            _phongBanService = phongBanService;
        }

        // GET: api/PhongBan
        [HttpGet]
        [SwaggerOperation(Summary = "Lấy danh sách phòng ban")]
        public async Task<ActionResult<IEnumerable<PhongBanDTO>>> GetAll()
        {
            try
            {
                var danhSach = await _phongBanService.GetAllAsync();
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Lấy danh sách phòng ban thành công.",
                    DuLieu = danhSach
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi lấy danh sách phòng ban: {ex.Message}",
                });
            }
        }

        // GET: api/PhongBan/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Tìm phòng ban")]
        public async Task<ActionResult<PhongBanDTO>> GetById(int id)
        {
            try
            {
                var phongBan = await _phongBanService.GetByIdAsync(id);
                if (phongBan == null)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy phòng ban với ID {id}.",
                    });
                }
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = $"Lấy phòng ban với ID {id} thành công.",
                    DuLieu = phongBan
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi lấy phòng ban: {ex.Message}",
                });
            }
        }

        // POST: api/PhongBan
        [HttpPost]
        [SwaggerOperation(Summary = "Tạo phòng ban")]
        public async Task<ActionResult<PhongBanDTO>> Create([FromBody] PhongBanDTO pbDto)
        {
            try
            {
                var created = await _phongBanService.CreateAsync(pbDto);
                return CreatedAtAction(nameof(GetById), new { id = created.MaPhong }, new
                {
                    ThanhCong = true,
                    ThongBao = "Tạo phòng ban thành công.",
                    DuLieu = created
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi tạo phòng ban: {ex.Message}",
                });
            }
        }

        // PUT: api/PhongBan/5
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Cập nhật phòng ban")]
        public async Task<IActionResult> Update(int id, [FromBody] PhongBanDTO pbDto)
        {
            try
            {
                var result = await _phongBanService.UpdateAsync(id, pbDto);
                var phongBan = await _phongBanService.GetByIdAsync(id);
                if (!result)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy phòng ban với ID {id}.",
                    });
                }
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = $"Cập nhật phòng ban với ID {id} thành công.",
                    DuLieu = phongBan
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi cập nhật phòng ban: {ex.Message}",
                });
            }
        }

        // DELETE: api/PhongBan/5
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Xóa phòng ban")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _phongBanService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy phòng ban với ID {id}.",
                    });
                }
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = $"Xóa phòng ban với ID {id} thành công.",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi xóa phòng ban: {ex.Message}",
                });
            }
        }
    }
}
