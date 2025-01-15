using ApplicationCore.Dtos.Hotel;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Services
{
    public interface IHotelService : IReadService<Hotel>, IWriteService<Hotel>
    {
        Task<IList<Hotel>> Search(SearchDto searchDto);
    }
}