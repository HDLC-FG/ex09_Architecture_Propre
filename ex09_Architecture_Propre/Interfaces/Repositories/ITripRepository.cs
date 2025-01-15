using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ITripRepository : IReadRepository<Trip>, IWriteRepository<Trip>
    {
    }
}