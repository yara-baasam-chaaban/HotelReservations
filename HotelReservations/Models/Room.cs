using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservations.Models
{
    public class Room
    {
        public int RoomId { get; set; } // Primary Key
        public int RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public int Floor { get; set; }
        public int NumberOfBeds { get; set; }
    }

    public enum RoomType
    {
        Standard,
        Suite,
        Deluxe
    }
}