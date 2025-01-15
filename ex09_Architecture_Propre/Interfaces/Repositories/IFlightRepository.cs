using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IFlightRepository : IReadRepository<Flight>, IWriteRepository<Flight>
    {
    }
}