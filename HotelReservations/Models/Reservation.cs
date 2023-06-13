using HotelReservations.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelReservations.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; } // Primary Key
        public DateTime ReservationDate { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; } // Foreign Key
        public Room Room { get; set; }

        [ForeignKey("Customer")]// Navigation Property
        public int CustomerId { get; set; } // Foreign Key
        public Customer Customer { get; set; } // Navigation Property
        public int NumberOfNights { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }


    public class UniqueCustomerNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (HotelReservationsContext)validationContext.GetService(typeof(HotelReservationsContext));

            var reservation = (Reservation)validationContext.ObjectInstance;

            if (dbContext.Reservations.Any(r => r.Customer.CustomerName == reservation.Customer.CustomerName))
            {
                return new ValidationResult("Customer name must be unique within reservations.");
            }

            return ValidationResult.Success;
        }
    }
}