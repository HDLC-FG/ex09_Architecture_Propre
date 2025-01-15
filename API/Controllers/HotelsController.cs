using ApplicationCore.Dtos.Hotel;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService hotelService;

        public HotelsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        // GET: api/Trips
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await hotelService.GetAll());
        }

        // GET: api/Trips/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var trip = await hotelService.GetById(id);
            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        // POST: api/Trips/Search
        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] SearchDto searchDto)
        {
            return Ok(await hotelService.Search(searchDto));
        }

        // POST: api/Trips
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Hotel hotel)
        {
            if (hotel == null) return BadRequest("Trip not found");

            await hotelService.Create(hotel);
            return Created();
        }

        // PUT: api/Trips/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Hotel hotel)
        {
            if (id != hotel.Id) return BadRequest();

            try
            {
                await hotelService.Update(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await hotelService.Exist(id))
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
            var trip = await hotelService.GetById(id);
            if (trip == null) return NotFound();

            await hotelService.Delete(trip);
            return NoContent();
        }
    }
}
