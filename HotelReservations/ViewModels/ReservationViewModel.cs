using HotelReservations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservations.ViewModels
{
    public class ReservationViewModel
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int SelectedCustomerId { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
        public DateTime ReservationDate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Number of nights must be a non-negative value.")]
        public int NumberOfNights { get; set; }
        public decimal TotalPrice { get; set; }

        public decimal PricePerNight { get; set; }

    }
}