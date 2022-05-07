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
        IEnumerable<Customer> GetAll(int status);
        Customer GetById(int id);
        Customer Create(object customer, string phone);
        void Update(Customer customer, string password = null);
        void Delete(int id);
        List<CustomerModel> GetListCustomer();
        CustomerModel GetCustomer(int id);
        bool ModifyCustomer(CustomerModel cus);
        bool ChangeStatusListCustomer(List<int> ls, int status);
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

        public IEnumerable<Customer> GetAll(int status)
        {
            return _context.Customers.Where(x => status != 0 ? x.Status == status : true).ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        public Customer Create(object customer, string phone)
        {
            var transaction = _context.Database.BeginTransaction();
            try {
                var dbCustomer = _context.Customers.Where(x => x.Phone == phone).FirstOrDefault();
                if (dbCustomer != null)
                    return null;
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

        public List<CustomerModel> GetListCustomer()
        {
            return _context.Customers.Select(x=>new CustomerModel() {Id=x.Id, Email=x.Email, Phone=x.Phone, FirstName=x.FirstName, LastName=x.LastName, CreatedAt=(DateTime)x.CreatedAt, Status=x.Status}).ToList();
        }
        public CustomerModel GetCustomer(int id)
        {
            return _context.Customers.Select(x => new CustomerModel() { Id = x.Id, Email = x.Email, Phone = x.Phone, FirstName = x.FirstName, LastName = x.LastName, CreatedAt = (DateTime)x.CreatedAt, Status = x.Status }).FirstOrDefault(x=>x.Id==id);

        }
        public bool ModifyCustomer(CustomerModel cus)
        {
            var w = _context.Customers.SingleOrDefault(x => x.Id == cus.Id);
            if (w != null)
            {
                w.FirstName = cus.FirstName;
                w.LastName = cus.LastName;
                w.Email = cus.Email;
                w.Status = cus.Status;
                if (cus.Password != "" && cus.Password != null)
                    w.PasswordHash = cus.Password;
                _context.SaveChanges();
            }
            return true;
        }
        public bool ChangeStatusListCustomer(List<int> ls, int status)
        {
            bool check = true;
            foreach (var item in ls)
            {
                var us = _context.Customers.SingleOrDefault(x => x.Id == item);
                if (us != null)
                {
                    if (us.Status != status) us.Status = status;
                    _context.SaveChanges();
                }
            }
            return check;
        }
    }
}