using ERP_System.Persistence.Entities;
using ERP_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace ERP_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TtreasuriesController (ITreasuryService treasury) : ControllerBase
    {
        private readonly ITreasuryService _treasury = treasury;

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var treasury = await _treasury.GetAllAsync();
            return Ok(treasury);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var treasury = await _treasury.GetByIdAsync(id);

            if (treasury == null)
                return NotFound();

            return Ok(treasury);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(Treasury treasury)
        {
            var createdTreasury = await _treasury.CreateAsync(treasury);
            return CreatedAtAction(nameof(Get), new { id = createdTreasury.TreasuryID }, createdTreasury);
        }

        [HttpPut("")]
        public async Task<IActionResult> Update(int id, Treasury treasury)
        {
            var updated = await _treasury.UpdateAsync(id, treasury);

            if (updated == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            var treasury = await _treasury.DeleteAsync(id);

            if (treasury == false)
                return NotFound();

            return NoContent();
        }
    }
}
