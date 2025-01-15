using ApplicationCore.Dtos.Hotel;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext dbContext;

        public HotelRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<Hotel>> GetAll()
        {
            return await dbContext.Hotels.ToListAsync();
        }

        public async Task<Hotel?> GetById(int id)
        {
            return await dbContext.Hotels.FindAsync(id);
        }

        public async Task Create(Hotel hotel)
        {
            await dbContext.Hotels.AddAsync(hotel);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Hotel hotel)
        {
            dbContext.Hotels.Update(hotel);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Hotel hotel)
        {
            dbContext.Hotels.Remove(hotel);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            return await dbContext.Hotels.AnyAsync(x => x.Id == id);
        }

        public async Task<IList<Hotel>> Search(SearchDto searchDto)
        {
            return await dbContext.Hotels.Where(x => x.City == searchDto.City 
                && x.Country == searchDto.Country
                && !x.Bookings.Any(y => y.StartDate < searchDto.EndDate && y.EndDate > searchDto.StartDate))
                .ToListAsync();
        }
    }
}
