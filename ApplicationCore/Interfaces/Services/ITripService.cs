using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITripService : IReadService<Trip>, IWriteService<Trip>
    {
        Task<decimal> GetTripTotalPrice(int id);
    }
}