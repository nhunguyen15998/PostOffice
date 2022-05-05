using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using post_office.Entities;
using post_office.Helpers;
using post_office.Models;

namespace post_office.Services
{
    public interface ICustomerService
    {
        Customer Authenticate(string phone, string password);
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer Create(object customer, string phone);
        void Update(Customer customer, string password = null);
        void Delete(int id);
        List<Customer> GetListCustomer();
    }

    public class CustomerService : ICustomerService
    {
        private DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public Customer Authenticate(string phone, string password)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Phone == phone);

            // check if Phone exists
            if (customer == null)
                return null;

            // check if password is correct
            if (!BCrypt.Net.BCrypt.Verify(password, customer.PasswordHash) == true)
                return null;

            // authentication successful
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        public Customer Create(object customer, string phone)
        {
            var transaction = _context.Database.BeginTransaction();
            try {
                if (_context.Customers.Any(x => x.Phone == phone))
                    throw new AppException("Phone \"" + phone + "\" is already taken");
                var item = new Customer(); 
                _context.Entry<Customer>(item).CurrentValues.SetValues(customer); //for few properties
                _context.Entry<Customer>(item).State = EntityState.Added;
                _context.SaveChanges();
                transaction.Commit();
                return item;
            } catch(Exception ex){
                transaction.Rollback();
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Update(Customer customerParam, string password = null)
        {
            var customer = _context.Customers.Find(customerParam.Id);
            if (customer == null)
                throw new AppException("User not found");

            // update Phone if it has changed
            if (!string.IsNullOrWhiteSpace(customerParam.Phone) && customerParam.Phone != customer.Phone)
            {
                // throw error if the new Phone is already taken
                if (_context.Customers.Any(x => x.Phone == customerParam.Phone))
                    throw new AppException("Phone " + customerParam.Phone + " is already taken");

                customer.Phone = customerParam.Phone;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(customerParam.FirstName))
                customer.FirstName = customerParam.FirstName;

            if (!string.IsNullOrWhiteSpace(customerParam.LastName))
                customer.LastName = customerParam.LastName;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                Helpers.Helpers.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                // customer.PasswordHash = passwordHash;
                // customer.PasswordSalt = passwordSalt;
            }

            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Customers.Find(id);
            if (user != null)
            {
                _context.Customers.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<Customer> GetListCustomer()
        {
            return _context.Customers.ToList();
        }
    }
}