using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Services
{
    public interface IFlightService : IReadService<Flight>, IWriteService<Flight>
    {
    }
}