using ApplicationCore.Dtos.Hotel;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;
using Infrastructure.Repositories;

namespace ApplicationCore.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public async Task<IList<Hotel>> GetAll()
        {
            return await hotelRepository.GetAll();
        }

        public async Task<Hotel?> GetById(int id)
        {
            return await hotelRepository.GetById(id);
        }

        public async Task Create(Hotel hotel)
        {
            await hotelRepository.Create(hotel);
        }

        public async Task Update(Hotel hotel)
        {
            await hotelRepository.Update(hotel);
        }

        public async Task Delete(Hotel hotel)
        {
            await hotelRepository.Delete(hotel);
        }

        public async Task<bool> Exist(int id)
        {
            return await hotelRepository.Exist(id);
        }

        public async Task<IList<Hotel>> Search(SearchDto searchDto)
        {
            return await hotelRepository.Search(searchDto);
        }
    }
}
