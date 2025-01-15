using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;
using Infrastructure.Repositories;

namespace ApplicationCore.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task<IList<Booking>> GetAll()
        {
            return await bookingRepository.GetAll();
        }

        public async Task<Booking?> GetById(int id)
        {
            return await bookingRepository.GetById(id);
        }

        public async Task<IList<Booking>> GetByHotelId(int hotelId)
        {
            return await bookingRepository.GetByHotelId(hotelId);
        }
    }
}
