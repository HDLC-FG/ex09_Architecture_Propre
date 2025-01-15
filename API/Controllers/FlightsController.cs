using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService flightService;

        public FlightsController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        // GET: api/Trips
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await flightService.GetAll());
        }

        // GET: api/Trips/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var trip = await flightService.GetById(id);
            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        // POST: api/Trips
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Flight flight)
        {
            if (flight == null) return BadRequest("Trip not found");

            await flightService.Create(flight);
            return Created();
        }

        // PUT: api/Trips/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Flight flight)
        {
            if (id != flight.Id) return BadRequest();

            try
            {
                await flightService.Update(flight);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await flightService.Exist(id))
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
            var trip = await flightService.GetById(id);
            if (trip == null) return NotFound();

            await flightService.Delete(trip);
            return NoContent();
        }
    }
}
