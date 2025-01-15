using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models;

namespace Infrastructure.Repositories
{
    public interface IBookingRepository : IReadRepository<Booking>
    {
        Task<IList<Booking>> GetByHotelId(int hotelId);
    }
}