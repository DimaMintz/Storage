using Storage5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Storage5.Repository
{
    public class ApplicationRepository : ICustomerRepository, IProductRepository, IStatusRepository, IOrderRepository, IReportRepository
    {
        private readonly OrdersContext context;
        private bool disposed = false;

        public ApplicationRepository()
        {
        }

        public ApplicationRepository(OrdersContext context){
            this.context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.Customers;
        }
        public void AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public Customer GetCustomerByID(int CustomerId)
        {
            return context.Customers.Find(CustomerId);
        }

        public void UpdateCustomer(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }

        public void RemoveCustomer(int CustomerId)
        {
            Customer customer = context.Customers.Find(CustomerId);
            context.Customers.Remove(customer);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products;
        }
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
        }

        public Product GetProductByID(int ProductId)
        {
            return context.Products.Find(ProductId);
        }

        public void UpdateProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
        }

        public void RemoveProduct(int ProductId)
        {
            Product product = context.Products.Find(ProductId);
            context.Products.Remove(product);
        }

        public IEnumerable<Status> GetAllStatuses()
        {
            return context.Statuses;
        }
        public void AddStatus(Status status)
        {
            context.Statuses.Add(status);
        }

        public Status GetStatusByID(int StatusId)
        {
            return context.Statuses.Find(StatusId);
        }

        public void UpdateStatus(Status Status)
        {
            context.Entry(Status).State = EntityState.Modified;
        }

        public void RemoveStatus(int StatusId)
        {
            Status status = context.Statuses.Find(StatusId);
            context.Statuses.Remove(status);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return context.Orders;
        }

        public Order GetOrderByID(int OrdertId)
        {
            return context.Orders.Find(OrdertId);
        }

        public void UpdateOrder(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }

        public void RemoveOrder(int OrderId)
        {
            Order order = context.Orders.Find(OrderId);
            context.Orders.Remove(order);
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
        }

        public IEnumerable<OrderProduct> GetAllOrderProducts()
        {
            return context.OrderProducts;
        }

        public void AddOrderProduct(OrderProduct orderProduct)
        {
            context.OrderProducts.Add(orderProduct);
        }
    }
}