using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            this.flightRepository = flightRepository;
        }

        public async Task<IList<Flight>> GetAll()
        {
            return await flightRepository.GetAll();
        }

        public async Task<Flight?> GetById(int id)
        {
            return await flightRepository.GetById(id);
        }

        public async Task Create(Flight flight)
        {
            await flightRepository.Create(flight);
        }

        public async Task Update(Flight flight)
        {
            await flightRepository.Update(flight);
        }

        public async Task Delete(Flight flight)
        {
            await flightRepository.Delete(flight);
        }

        public async Task<bool> Exist(int id)
        {
            return await flightRepository.Exist(id);
        }
    }
}
