using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TripRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<Trip>> GetAll()
        {
            return await dbContext.Trips.ToListAsync();
        }

        public async Task<Trip?> GetById(int id)
        {
            return await dbContext.Trips.Include(t => t.Flights)
                .Include(t => t.Hotels)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task Create(Trip trip)
        {
            await dbContext.Trips.AddAsync(trip);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Trip trip)
        {
            dbContext.Trips.Update(trip);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Trip trip)
        {
            dbContext.Trips.Remove(trip);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            return await dbContext.Trips.AnyAsync(x => x.Id == id);
        }
    }
}
