using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            using var context = new HotelDbContext();
            context.Hotels.Add(hotel);
            await context.SaveChangesAsync();
            return hotel;
        }

        public async void DeleteHotelById(int id)
        {
            using var context = new HotelDbContext();
            var hotel = await GetHotelById(id);
            context.Hotels.Remove(hotel);
            context.SaveChanges();
        }

        // Asynchronius method..
        public async Task<List<Hotel>> GetAllHotels()
        {
            using var context = new HotelDbContext();
            return await context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            using var context = new HotelDbContext();
            return await context.Hotels.FindAsync(id) ?? new Hotel();
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using var context = new HotelDbContext();
            context.Hotels.Update(hotel);
            await context.SaveChangesAsync();
            return hotel;
        }

        
    }

}
