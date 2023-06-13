using HotelReservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservations.Repository
{
    public interface IRoomRepository
    {
        Room GetById(int? id);
        void Add(Room room);
        void Update(Room room);
        void Delete(Room room);
        List<Room> GetAll();

        decimal GetPrice(int? id);
    }
}