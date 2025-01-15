using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            this.tripRepository = tripRepository;
        }

        public async Task<IList<Trip>> GetAll()
        {
            return await tripRepository.GetAll();
        }

        public async Task<Trip?> GetById(int id)
        {
            return await tripRepository.GetById(id);
        }

        public async Task Create(Trip trip)
        {
            await tripRepository.Create(trip);
        }

        public async Task Update(Trip trip)
        {
            await tripRepository.Update(trip);
        }

        public async Task Delete(Trip trip)
        {
            await tripRepository.Delete(trip);
        }

        public async Task<bool> Exist(int id)
        {
            return await tripRepository.Exist(id);
        }

        public async Task<decimal> GetTripTotalPrice(int id)
        {
            var trip = await tripRepository.GetById(id);
            if (trip == null) return 0;
            var flightPrice = trip.Flights.FirstOrDefault(x => x.Origin == trip.Origin)?.Price ?? 0;

            return flightPrice + trip.Hotels.Sum(x => x.Price);
        }
    }
}
