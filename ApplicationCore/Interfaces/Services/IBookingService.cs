using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Services
{
    public interface IBookingService : IReadService<Booking>
    {
        Task<IList<Booking>> GetByHotelId(int hotelId);
    }
}