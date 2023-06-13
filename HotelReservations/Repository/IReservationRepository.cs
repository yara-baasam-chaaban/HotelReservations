using HotelReservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservations.Repository
{
    public interface IReservationRepository
    {
        Reservation GetById(int id);
        IEnumerable<Reservation> GetAll();
        void Add(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(Reservation reservation);
        bool IsRoomBooked(int roomId, DateTime reservationDate, int numberOfNights);
        void Reload(Reservation reservation);
    }
}