using ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await bookingService.GetAll());
        }

        // GET: api/Booking/5
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var trip = await bookingService.GetById(id);
            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        // GET: api/Booking/5
        [HttpGet("GetByHotel/{id}")]
        public async Task<IActionResult> GetByHotelId(int id)
        {
            var trip = await bookingService.GetByHotelId(id);
            if (trip == null || trip.Count == 0)
            {
                return NotFound();
            }

            return Ok(trip);
        }
    }
}
