using HotelReservations.DAL;
using HotelReservations.Models;
using HotelReservations.Repository;
using HotelReservations.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace HotelReservations.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRoomRepository _roomRepository;

        public ReservationController()
        {
            _reservationRepository = new ReservationRepository(new HotelReservationsContext());
            _customerRepository = new CustomerRepository(new HotelReservationsContext());
            _roomRepository = new RoomRepository(new HotelReservationsContext());
        }

        public ActionResult View()
        {
            var reservations = _reservationRepository.GetAll();
            return View(reservations);
        }
        public ActionResult Create(int? roomId)
        {
            
            var viewModel = new ReservationViewModel();
            viewModel.PricePerNight = _roomRepository.GetPrice(roomId);
            viewModel.CustomerList = GetCustomerList();
            viewModel.RoomNumber = _roomRepository.GetById(roomId).RoomNumber;//(int)roomId;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ReservationViewModel viewModel, int? roomId)
        {
            if (ModelState.IsValid)
            {

                // Create a new reservation object and populate its properties
                var reservation = new Reservation
                {
                    RoomId = (int)roomId,
                    CustomerId = viewModel.SelectedCustomerId,
                    ReservationDate= viewModel.ReservationDate,
                    TotalPrice= _roomRepository.GetPrice(roomId) * viewModel.NumberOfNights,
                    NumberOfNights= viewModel.NumberOfNights
                };

                // Check if the room is already booked for the given reservation dates
                bool isRoomBooked = _reservationRepository.IsRoomBooked(reservation.RoomId, reservation.ReservationDate, reservation.NumberOfNights);
                if (isRoomBooked)
                {
                    ModelState.AddModelError("", "The selected room is already booked for the given dates.");
                    ViewBag.SuccessMessage = "Reservation can't be created because the room is already booked.";
                    viewModel.CustomerList = GetCustomerList();
                    return View(viewModel);
                }

                // Save the reservation to the repository or perform any other necessary operations
                _reservationRepository.Add(reservation);

                // Set the success message
                ViewBag.SuccessMessage = "Reservation created successfully.";
            }

            // If the model is not valid, populate the customer list again and return the view with validation errors
            viewModel.CustomerList = GetCustomerList();
            
            return View(viewModel);
        }

        private List<SelectListItem> GetCustomerList()
        {
            // Retrieve the list of customers from the repository
            var customers = _customerRepository.GetAll();

            // Create a list of SelectListItem objects based on the customer list
            var customerList = customers.Select(c => new SelectListItem
            {
                Value = c.CustomerId.ToString(),
                Text = c.CustomerName
            }).Distinct().ToList();

            return customerList;

        }

        private List<SelectListItem> GetRoomList()
        {
            // Retrieve the list of customers from the repository
            var rooms = _roomRepository.GetAll();

            // Create a list of SelectListItem objects based on the customer list
            var roomList = rooms.Select(c => new SelectListItem
            {
                Value = c.RoomId.ToString(),
                Text = c.RoomNumber.ToString()
            }).Distinct().ToList();

            return roomList;

        }

       
        public ActionResult Details(int id)
        {
            var reservation = _reservationRepository.GetById(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }

            return View(reservation);
        }

        public ActionResult Delete(int id)
        {
            var reservation = _reservationRepository.GetById(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }

            return View(reservation);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var reservation = _reservationRepository.GetById(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }

            _reservationRepository.Delete(reservation);
            return RedirectToAction("View");
        }
    }
}