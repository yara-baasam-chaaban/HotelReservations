using HotelReservations.DAL;
using HotelReservations.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.Entity.Infrastructure;

namespace HotelReservations.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelReservationsContext _context;

        public ReservationRepository(HotelReservationsContext context)
        {
            _context = context;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations.Include(x=>x.Rooms).Include(c=>c.Customers).ToList();
        }

        public void Add(Reservation reservation)
        {

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public void Delete(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
        public Reservation GetById(int id)
        {
            return _context.Reservations.Include(r => r.Room).Include(r => r.Customer).FirstOrDefault(r => r.ReservationId == id);
        }

        public void Update(Reservation reservation)
        {
                    _context.Entry(reservation).State = EntityState.Modified;
                    _context.SaveChanges();
            
        }


        public bool IsRoomBooked(int roomId, DateTime reservationDate, int numberOfNights)
        {
            DateTime endDate = reservationDate.AddDays(numberOfNights - 1);

            // Check if there are any reservations for the given room and overlapping dates
            bool isBooked = _context.Reservations.Any(r =>
                r.RoomId == roomId &&
                (r.ReservationDate <= endDate && endDate <= DbFunctions.AddDays(r.ReservationDate, r.NumberOfNights - 1)));

            return isBooked;
        }

        public void Reload(Reservation reservation)
        {
            _context.Entry(reservation).Reload();
        }
           
    }
}