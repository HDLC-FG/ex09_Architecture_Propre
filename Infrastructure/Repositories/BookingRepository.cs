using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BookingRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<Booking>> GetAll()
        {
            return await dbContext.Bookings.ToListAsync();
        }

        public async Task<Booking?> GetById(int id)
        {
            return await dbContext.Bookings.FindAsync(id);
        }

        public async Task<IList<Booking>> GetByHotelId(int hotelId)
        {
            return await dbContext.Bookings.Where(x => x.HotelId == hotelId).ToListAsync();
        }
    }
}
