using HotelReservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservations.Repository
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);

        List<Customer> GetAll();

        Customer GetExistingReservation(string customerName);
    }
}