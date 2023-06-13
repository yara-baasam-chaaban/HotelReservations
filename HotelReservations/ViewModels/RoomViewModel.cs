using HotelReservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservations.ViewModels
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        public int RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }
        public int Floor { get; set; }
        public int NumberOfBeds { get; set; }
    }
}