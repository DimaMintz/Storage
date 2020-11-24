using Storage5.Models;
using System;
using System.Collections.Generic;

namespace Storage5.Repository
{
    public interface IReportRepository : IDisposable
    {
        IEnumerable<Order> GetAllOrders();

        IEnumerable<Customer> GetAllCustomers();

        IEnumerable<Product> GetAllProducts();

        IEnumerable<OrderProduct> GetAllOrderProducts();
    }
}
