using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PGMate.Models;

namespace PGMate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CleaningTaskController : ControllerBase
    {
        private readonly ICleaningService _service;

        public CleaningTaskController(ICleaningService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _service.GetByIdAsync(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CleaningTaskDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CleaningTaskDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

}
