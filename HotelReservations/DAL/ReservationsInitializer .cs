using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HotelReservations.Models;
using System.Data.Entity.Core.Metadata.Edm;

namespace HotelReservations.DAL
{

    public class ReservationsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HotelReservationsContext>
    {
        protected override void Seed(HotelReservationsContext context)
        {
            // Create rooms using enum values
            var rooms = new List<Room>
            {
            new Room { RoomNumber = 101, RoomType = RoomType.Standard, PricePerNight = 100, Floor = 1, NumberOfBeds = 2 },
            new Room { RoomNumber = 201, RoomType = RoomType.Suite, PricePerNight = 200, Floor = 2, NumberOfBeds = 4 },
            new Room { RoomNumber = 301, RoomType = RoomType.Deluxe, PricePerNight = 300, Floor = 3, NumberOfBeds = 3 }
        };

            context.Rooms.AddRange(rooms);
            context.SaveChanges();

            // Create customers
            var customers = new List<Customer>
        {
            new Customer { CustomerName = "John Doe", Address = "123 Main St", Phone = "555-1234", Email = "john@example.com", DateOfBirth = new DateTime(1990, 1, 1) },
            new Customer { CustomerName = "Jane Smith", Address = "456 Elm St", Phone = "555-5678", Email = "jane@example.com", DateOfBirth = new DateTime(1995, 5, 5) }
        };

            context.Customers.AddRange(customers);
            context.SaveChanges();

            // Create reservations
            var reservations = new List<Reservation>
        {
            new Reservation { ReservationDate = DateTime.Now, RoomId = 1, CustomerId = 1, NumberOfNights = 3, TotalPrice = 300 },
            new Reservation { ReservationDate = DateTime.Now, RoomId = 2, CustomerId = 2, NumberOfNights = 2, TotalPrice = 400 }
        };

            context.Reservations.AddRange(reservations);
            context.SaveChanges();

            base.Seed(context);
        }
    }

}
















