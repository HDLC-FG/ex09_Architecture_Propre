using ApplicationCore.Dtos.Hotel;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models;

namespace Infrastructure.Repositories
{
    public interface IHotelRepository : IReadRepository<Hotel>, IWriteRepository<Hotel>
    {
        Task<IList<Hotel>> Search(SearchDto searchDto);
    }
}