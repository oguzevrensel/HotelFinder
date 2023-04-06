using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {

        private readonly IHotelRepository _service;

        public HotelManager(IHotelRepository repository)
        {
            _service = repository;
        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            return await _service.CreateHotel(hotel);
        }

        public void DeleteHotelById(int id)
        {
            _service.DeleteHotelById(id);
        }

        public async Task<List<Hotel>> GetAllHotels()   
        {
            return await _service.GetAllHotels();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            if (id > 0)
            {
                return await _service.GetHotelById(id);
            }
            throw new Exception("Id 1 den küçük olamaz");
            
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _service.UpdateHotel(hotel);
        }

    }

}
