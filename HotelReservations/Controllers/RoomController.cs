using HotelReservations.DAL;
using HotelReservations.Models;
using HotelReservations.Repository;
using HotelReservations.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservations.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public RoomController()
        {
            _roomRepository = new RoomRepository(new HotelReservationsContext());
        }

        public ActionResult Index()
        {
            var rooms = _roomRepository.GetAll();
            var viewModel = new List<RoomViewModel>();
            foreach (var room in rooms)
            {
                var roomViewModel = new RoomViewModel
                {
                    ID = room.RoomId,
                    RoomNumber = room.RoomNumber,
                    RoomType = room.RoomType,
                    Price = room.PricePerNight,
                    Floor = room.Floor,
                    NumberOfBeds = room.NumberOfBeds
                };
                viewModel.Add(roomViewModel);
            }
            return View(viewModel);
        }



        public ActionResult View()
        {
            var rooms = _roomRepository.GetAll();
            return View(rooms);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepository.Add(room);
                return RedirectToAction("Index");
            }

            return View(room);
        }

        public ActionResult Edit(int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            return View(room);
        }

        [HttpPost]
        public ActionResult Edit(int id, Room room)
        {
            if (id != room.RoomId)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                _roomRepository.Update(room);
                return RedirectToAction("Index");
            }

            return View(room);
        }

        public ActionResult Details(int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            return View(room);
        }

        public ActionResult Delete(int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            return View(room);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            _roomRepository.Delete(room);
            return RedirectToAction("Index");
        }


    }

}