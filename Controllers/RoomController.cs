using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PGMate.Models;
using PGMate.Services;

namespace PGMate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _service.GetByIdAsync(id);
            return room == null ? NotFound() : Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoomDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoomDTO dto)
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
