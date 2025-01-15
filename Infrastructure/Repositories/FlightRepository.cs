using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FlightRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<Flight>> GetAll()
        {
            return await dbContext.Flights.ToListAsync();
        }

        public async Task<Flight?> GetById(int id)
        {
            return await dbContext.Flights.FindAsync(id);
        }

        public async Task Create(Flight trip)
        {
            await dbContext.Flights.AddAsync(trip);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Flight trip)
        {
            dbContext.Flights.Update(trip);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Flight trip)
        {
            dbContext.Flights.Remove(trip);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            return await dbContext.Flights.AnyAsync(x => x.Id == id);
        }
    }
}
