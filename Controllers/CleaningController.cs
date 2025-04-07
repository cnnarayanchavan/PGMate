
using Microsoft.AspNetCore.Mvc;
using PGMate;
using PGMate.Models;

namespace PG_LIFE_UU.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CleaningController : ControllerBase
    {
        private readonly ICleaningService _cleaningService;

        public CleaningController(ICleaningService cleaningService)
        {
            _cleaningService = cleaningService;
        }

        // GET: api/cleaning
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _cleaningService.GetAllTasksAsync();
            return Ok(tasks);
        }

        // POST: api/cleaning
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CleaningTaskDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.ScheduledTime < DateTime.Now)
                return BadRequest("Scheduled time must be in the future.");

            var task = await _cleaningService.AddTaskAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
        }

        // PUT: api/cleaning/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
        {
            var validStatuses = new[] { "Pending", "Completed", "Missed" };
            if (!validStatuses.Contains(status))
                return BadRequest("Invalid status. Use Pending, Completed, or Missed.");

            var result = await _cleaningService.UpdateTaskStatusAsync(id, status);
            if (!result)
                return NotFound($"Task with id {id} not found.");

            return NoContent();
        }

        // DELETE: api/cleaning/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cleaningService.DeleteTaskAsync(id);
            if (!result)
                return NotFound($"Task with id {id} not found.");

            return NoContent();
        }
    }

}
