using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Abstract
{
    // ASENKRONİSE YAPTIK
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotels();

        Task<Hotel> GetHotelById(int id);

        Task<Hotel> CreateHotel(Hotel hotel);

        Task<Hotel> UpdateHotel(Hotel hotel);

        void DeleteHotelById(int id);
    }
}
