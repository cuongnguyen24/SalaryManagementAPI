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
        public async Task<ActionResult<IEnumerable<NhanVienDTO>>> GetAll()
        {
            var list = await _nhanVienService.GetAllAsync();
            return Ok(list);
        }

        // GET: api/NhanVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVienDTO>> GetById(int id)
        {
            var nv = await _nhanVienService.GetByIdAsync(id);
            if (nv == null)
                return NotFound();

            return Ok(nv);
        }

        // POST: api/NhanVien
        [HttpPost]
        public async Task<ActionResult<NhanVienDTO>> Create([FromBody] NhanVienDTO nvDto)
        {
            var created = await _nhanVienService.CreateAsync(nvDto);
            return CreatedAtAction(nameof(GetById), new { id = created.MaNV }, created);
        }

        // PUT: api/NhanVien/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NhanVienDTO nvDto)
        {
            var result = await _nhanVienService.UpdateAsync(id, nvDto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/NhanVien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _nhanVienService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
