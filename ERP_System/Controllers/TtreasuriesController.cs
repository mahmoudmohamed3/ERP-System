using ERP_System.Persistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TtreasuriesController : ControllerBase
    {
        private readonly static List<Treasury> _treasuries = [
            new Treasury() {
                TreasuryID = 1,
                TreasuryName = "Vodafone Cach",
                InitialBalance = 100
            }
        ];

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_treasuries);
        }

        [HttpGet ("{id}")]
        public IActionResult Get(int id)
        {
            var treasury = _treasuries.SingleOrDefault(x=> x.TreasuryID == id);

            if (treasury == null)
                return NotFound();

            return Ok(treasury);
        }

        [HttpPost ("")]
        public IActionResult Create(Treasury treasury)
        {
            treasury.TreasuryID = _treasuries.Count() + 1;

            _treasuries.Add(treasury);

            return CreatedAtAction(nameof(Get), new { id = treasury.TreasuryID }, treasury);

        }

        [HttpPut ("")]
        public IActionResult Update(int id , Treasury treasury)
        {
            var currentTreasury = _treasuries.Find(x=> x.TreasuryID == id );

            if (currentTreasury == null)
                return NotFound();

            currentTreasury.TreasuryName = treasury.TreasuryName;
            currentTreasury.InitialBalance = treasury.InitialBalance;
            currentTreasury.LastUpdatedOn = DateTime.Now;
            currentTreasury.IsActive = treasury.IsActive;

            return NoContent();


        }

        [HttpDelete ("")]
        public IActionResult Delete (int id)
        {
            var treasury = _treasuries.SingleOrDefault(x => x.TreasuryID == id);

            if (treasury == null)
                return NotFound();

            _treasuries.Remove(treasury);

            return NoContent();
        }


    }
}
