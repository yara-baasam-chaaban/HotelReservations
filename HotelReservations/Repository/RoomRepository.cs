using HotelReservations.DAL;
using HotelReservations.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelReservations.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelReservationsContext _context;

        public RoomRepository(HotelReservationsContext context)
        {
            _context = context;
        }

        public void Add(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void Delete(Room room)
        {
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }

        public List<Room> GetAll()
        {

             return   _context.Rooms.ToList();
                  
        }

        public Room GetById(int? id)
        {
            return _context.Rooms.Where(x => x.RoomId == id).FirstOrDefault();
        }

        public decimal GetPrice(int? id)
        {
            return _context.Rooms.Where(x => x.RoomId == id).Select(x => x.PricePerNight).FirstOrDefault();
        }

        public void Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            _context.SaveChanges();
        }


    }
}