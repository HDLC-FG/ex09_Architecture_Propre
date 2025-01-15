using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripService tripService;

        public TripsController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        // GET: api/Trips
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await tripService.GetAll());
        }

        // GET: api/Trips/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var trip = await tripService.GetById(id);
            if (trip == null)
            {
                return NotFound();
            }
            
            return Ok(trip);
        }

        // GET: api/Trips/5
        [HttpGet("TotalPrice/{id}")]
        public async Task<IActionResult> GetTotalPrice(int id)
        {
            return Ok(await tripService.GetTripTotalPrice(id));
        }

        // POST: api/Trips
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Trip trip)
        {
            if (trip == null) return BadRequest("Trip not found");

            await tripService.Create(trip);
            return Created();
        }

        // PUT: api/Trips/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Trip trip)
        {
            if (id != trip.Id) return BadRequest();

            try
            {
                await tripService.Update(trip);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await tripService.Exist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Trips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = await tripService.GetById(id);
            if (trip == null) return NotFound();

            await tripService.Delete(trip);
            return NoContent();
        }
    }
}
