namespace SalaryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HopDongController : ControllerBase
    {
        private IHopDongService _hopDongService;

        public HopDongController(IHopDongService hopDongService)
        {
            _hopDongService = hopDongService;
        }

        // GET: api/HopDong
        [HttpGet]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Lấy danh sách hợp đồng")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _hopDongService.GetAllAsync();
                return Ok(new
                {
                    ThanhCong = true,
                    ThongBao = "Lấy danh sách hợp đồng thành công.",
                    DuLieu = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ThanhCong = false, ThongBao = $"Lỗi: {ex.Message}" });
            }
        }

        // GET: api/HopDong/5
        [HttpGet("{maHD}")]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Lấy hợp đồng theo mã")]
        public async Task<IActionResult> GetById(int maHD)
        {
            try
            {
                var result = await _hopDongService.GetByIdAsync(maHD);
                if (result == null)
                    return NotFound(new { ThanhCong = false, ThongBao = $"Không tìm thấy hợp đồng với mã {maHD}." });

                return Ok(new { ThanhCong = true, ThongBao = "Lấy hợp đồng thành công.", DuLieu = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ThanhCong = false, ThongBao = $"Lỗi: {ex.Message}" });
            }
        }

        // GET: api/HopDong/NhanVien/3
        [HttpGet("NhanVien/{maNV}")]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Lấy hợp đồng theo mã nhân viên")]
        public async Task<IActionResult> GetByNhanVienId(int maNV)
        {
            var result = await _hopDongService.GetByNhanVienIdAsync(maNV);
            return Ok(result);
        }

        // GET: api/HopDong/NhanVien/3/Current
        [HttpGet("NhanVien/{maNV}/Current")]
        [Authorize(Roles = "1,2,3,4,5")] // Cho cả trưởng phòng, kế toán,nhân viên được xem hợp đồng đang hiệu lực
        [SwaggerOperation(Summary = "Lấy hợp đồng hiện tại của nhân viên")]
        public async Task<IActionResult> GetCurrentHopDong(int maNV)
        {
            try
            {
                var result = await _hopDongService.GetCurrentHopDongByNhanVienIdAsync(maNV);
                if (result == null)
                    return NotFound(new { ThanhCong = false, ThongBao = "Không có hợp đồng hiệu lực." });

                return Ok(new { ThanhCong = true, ThongBao = "Lấy hợp đồng hiện tại thành công.", DuLieu = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ThanhCong = false, ThongBao = $"Lỗi: {ex.Message}" });
            }
        }

        // POST: api/HopDong
        [HttpPost]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Tạo mới hợp đồng")]
        public async Task<IActionResult> Create([FromBody] HopDongDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ThanhCong = false,
                    ThongBao = "Dữ liệu không hợp lệ.",
                    LoiChiTiet = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage))
                });
            }

            try
            {
                var result = await _hopDongService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { maHD = result.MaHD }, new
                {
                    ThanhCong = true,
                    ThongBao = "Tạo hợp đồng thành công.",
                    DuLieu = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ThanhCong = false, ThongBao = $"Lỗi: {ex.Message}" });
            }
        }

        // PUT: api/HopDong/5
        [HttpPut("{maHD}")]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Cập nhật hợp đồng")]
        public async Task<IActionResult> Update(int maHD, [FromBody] HopDongDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ThanhCong = false,
                    ThongBao = "Dữ liệu không hợp lệ.",
                    LoiChiTiet = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage))
                });
            }

            try
            {
                var success = await _hopDongService.UpdateAsync(maHD, dto);
                if (!success)
                    return NotFound(new { ThanhCong = false, ThongBao = $"Không tìm thấy hợp đồng với mã {maHD}." });

                return Ok(new { ThanhCong = true, ThongBao = "Cập nhật hợp đồng thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ThanhCong = false, ThongBao = $"Lỗi: {ex.Message}" });
            }
        }

        // DELETE: api/HopDong/5
        [HttpDelete("{maHD}")]
        [Authorize(Roles = "1,2")]
        [SwaggerOperation(Summary = "Xóa hợp đồng")]
        public async Task<IActionResult> Delete(int maHD)
        {
            try
            {
                var success = await _hopDongService.DeleteAsync(maHD);
                if (!success)
                    return NotFound(new { ThanhCong = false, ThongBao = $"Không tìm thấy hợp đồng với mã {maHD}." });

                return Ok(new { ThanhCong = true, ThongBao = "Xóa hợp đồng thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ThanhCong = false, ThongBao = $"Lỗi: {ex.Message}" });
            }
        }
    }
}