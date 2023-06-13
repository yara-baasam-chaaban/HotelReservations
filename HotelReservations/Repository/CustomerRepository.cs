using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelReservations.DAL;
using HotelReservations.Models;

namespace HotelReservations.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HotelReservationsContext _context;

        public CustomerRepository(HotelReservationsContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
        public List<Customer> GetAll()
        {
            return _context.Customers
              .GroupBy(c => c.CustomerName)
              .Select(g => g.FirstOrDefault())
              .ToList();
        }

        public Customer GetById(int id)
        {
           return _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Customer GetExistingReservation(string customerName)
        { 
        return _context.Customers.FirstOrDefault(c => c.CustomerName == customerName);
        }
    }
}