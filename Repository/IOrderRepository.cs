using Storage5.Models;
using System;
using System.Collections.Generic;

namespace Storage5.Repository
{
    public interface IOrderRepository : IDisposable
    { 
        IEnumerable<Order> GetAllOrders();

        Order GetOrderByID(int OrdertId);

        void UpdateOrder(Order order);

        void SaveChanges();

        void RemoveOrder(int OrderId);

        void AddOrder(Order order);

        IEnumerable<Customer> GetAllCustomers();

        IEnumerable<Product> GetAllProducts();

        IEnumerable<OrderProduct> GetAllOrderProducts();

        void AddOrderProduct(OrderProduct orderProduct);
    }
}
