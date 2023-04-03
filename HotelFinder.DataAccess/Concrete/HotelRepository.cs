using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using var context = new HotelDbContext();
            context.Hotels.Add(hotel);
            context.SaveChanges();
            return hotel;
        }

        public void DeleteHotelById(int id)
        {
            using var context = new HotelDbContext();
            var hotel = GetHotelById(id);
            context.Hotels.Remove(hotel);
            context.SaveChanges();
        }

        public List<Hotel> GetAllHotels()
        {
            using var context = new HotelDbContext();
            return context.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
            using var context = new HotelDbContext();
            return context.Hotels.Find(id) ?? new Hotel();
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using var context = new HotelDbContext();
            context.Hotels.Update(hotel);
            context.SaveChanges();
            return hotel;
        }

    }

}
