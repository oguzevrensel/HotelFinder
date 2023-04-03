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
        public Hotel CreateHotel(Hotel hotel)
        {
            return _service.CreateHotel(hotel);
        }

        public void DeleteHotelById(int id)
        {
            _service.DeleteHotelById(id);
        }

        public List<Hotel> GetAllHotels()
        {
            return _service.GetAllHotels();
        }

        public Hotel GetHotelById(int id)
        {
            if (id > 0)
            {
                return _service.GetHotelById(id);
            }
            throw new Exception("Id 1 den küçük olamaz");
            
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            return _service.UpdateHotel(hotel);
        }

    }

}
