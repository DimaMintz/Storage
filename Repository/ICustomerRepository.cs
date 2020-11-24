using Storage5.Models;
using System;
using System.Collections.Generic;

namespace Storage5.Repository
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Customer> GetAllCustomers();

        Customer GetCustomerByID(int CustomerId);

        void UpdateCustomer(Customer Customer);

        void SaveChanges();

        void RemoveCustomer(int CustomerId);

        void AddCustomer(Customer customer);
    }
}
