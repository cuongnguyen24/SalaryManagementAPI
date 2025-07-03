namespace SalaryManagementAPI.Controllers
{
    [Authorize(Roles = "1")]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuService _chucVuService;

        public ChucVuController(IChucVuService chucVuService)
        {
            _chucVuService = chucVuService;
        }

        // GET: api/ChucVu
        [HttpGet]
        [SwaggerOperation(Summary = "Lấy chức vụ")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var danhSach = await _chucVuService.GetAllAsync();
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Lấy danh sách chức vụ thành công.",
                    DuLieu = danhSach
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi lấy danh sách chức vụ: {ex.Message}",
                });
            }
        }

        // GET: api/ChucVu/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Lấy chức vụ theo id")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var chucVu = await _chucVuService.GetByIdAsync(id);
                if (chucVu == null)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy chức vụ với ID {id}.",
                    });
                }
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = $"Lấy chức vụ với ID {id} thành công.",
                    DuLieu = chucVu
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi lấy chức vụ: {ex.Message}",
                });
            }
        }

        // POST: api/ChucVu
        [HttpPost]
        [SwaggerOperation(Summary = "Thêm chức vụ")]
        public async Task<ActionResult> Create([FromBody] ChucVuDTO dto)
        {
            try
            {
                var created = await _chucVuService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.MaChucVu }, new
                {
                    ThanhCong = true,
                    ThongBao = "Tạo chức vụ thành công.",
                    DuLieu = created
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi tạo chức vụ: {ex.Message}",
                });
            }
        }

        // PUT: api/ChucVu/5
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Cập nhật chức vụ")]
        public async Task<IActionResult> Update(int id, [FromBody] ChucVuDTO dto)
        {
            try
            {
                var updated = await _chucVuService.UpdateAsync(id, dto);
                if (!updated)
                {
                    return NotFound(new
                    {
                        ThanhCong = false,
                        ThongBao = $"Không tìm thấy chức vụ với ID {id}.",
                    });
                }
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = $"Cập nhật chức vụ với ID {id} thành công.",
                    DuLieu = updated
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi cập nhật chức vụ: {ex.Message}",
                });
            }
        }

        // DELETE: api/ChucVu/5
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Xóa chức vụ")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _chucVuService.DeleteAsync(id);
                if (!success)
                    return NotFound(new
                    {
                        ThongBao = $"Không tìm thấy chức vụ với ID {id}."
                    });
                return Ok(new
                {
                    ThongBao = $"Xóa chức vụ với ID {id} thành công."
                });
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new
                {
                    ThanhCong = false,
                    ThongBao = $"Lỗi khi xóa chức vụ: {ex.Message}"
                });
            }
            
        }
    }
}
