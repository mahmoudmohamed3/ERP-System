using ERP_System.Persistence.Entities;
using ERP_System.Services;
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
        public IActionResult GetAll()
        {
            var treasury = _treasury.GetAll();

            return Ok(treasury);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var treasury = _treasury.GetById(id);

            if (treasury == null)
                return NotFound();

            return Ok(treasury);
        }

        [HttpPost("")]
        public IActionResult Create(Treasury treasury)
        {

            _treasury.Create(treasury);

            return CreatedAtAction(nameof(Get) , new { id  = treasury.TreasuryID } , treasury);

        }

        [HttpPut("")]
        public IActionResult Update(int id, Treasury treasury)
        {
            var updated = _treasury.Update(id , treasury);


            if (updated == false)
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpDelete("")]
        public IActionResult Delete(int id)
        {
            var treasury = _treasury.Delete(id);

            if (treasury == false)
                return NotFound();

            return NoContent();
        }


    }
}
