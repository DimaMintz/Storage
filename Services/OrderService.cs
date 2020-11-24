using Storage5.Models;
using Storage5.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Storage5.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository OrderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            this.OrderRepository = OrderRepository;
        }

        public List<OrderInfoViewModel> CreateOrderInfoViewModel()
        {
            List<OrderInfoViewModel> OrderInfoViewModels = new List<OrderInfoViewModel>();
            foreach (var order in OrderRepository.GetAllOrders())
            {
                int currentOrderId = order.Id;
                Customer currentCustomer = OrderRepository.GetAllCustomers().First(c => c.Id == order.CustomerId);
                OrderInfoViewModel orderInfoViewModel = new OrderInfoViewModel
                {
                    OrderId = currentOrderId,
                    OrderCreationDate = order.CreationDate,
                    OrderEstimatedDate = order.EstimatedDate,
                    OrderStatusId = order.StatusId,
                    OrderCustomerId = order.CustomerId,
                    CustomerId = currentCustomer.Id,
                    CustomerFname = currentCustomer.Fname,
                    CustomerLname = currentCustomer.Lname,
                    CustomerAddress = currentCustomer.Address,
                    CustomerPhone = currentCustomer.Phone
                };
                foreach (var op in OrderRepository.GetAllOrderProducts().Where(o => o.OrderId == currentOrderId))
                {
                    Product currentProduct = OrderRepository.GetAllProducts().Where(p => p.Id == op.ProductId).First();
                    orderInfoViewModel.products.Add(currentProduct);
                }
                OrderInfoViewModels.Add(orderInfoViewModel);
            }
            return OrderInfoViewModels;
        }

        public List<SelectListItem> ListOfCustomers()
        {
            List<SelectListItem> customersList = new List<SelectListItem>();
            foreach (var c in OrderRepository.GetAllCustomers())
            {
                customersList.Add(new SelectListItem() { Text = c.Fname + " " + c.Lname, Value = c.Id.ToString() });
            }
            return customersList;
        }

        public OrderCreationViewModel ListOfProducts()
        {
            OrderCreationViewModel orderCreationViewModel = new OrderCreationViewModel();
            IEnumerable<Product> products = OrderRepository.GetAllProducts();
            foreach (var p in products)
            {
                orderCreationViewModel.Products.Add(new OrderedProduct()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    CreationDate = p.CreationDate,
                    ExpiredDate = p.ExpiredDate,
                    IsOrdered = false
                });
            }
            return orderCreationViewModel;
        }

        public void CreateOrderWithProducts(OrderCreationViewModel orderCreationViewModel)
        {
            var order = new Order
            {
                Id = orderCreationViewModel.Id,
                CreationDate = orderCreationViewModel.CreationDate,
                EstimatedDate = orderCreationViewModel.EstimatedDate,
                StatusId = orderCreationViewModel.StatusId,
                CustomerId = orderCreationViewModel.CustomerId
            };
            OrderRepository.AddOrder(order);
            try
            {
                OrderRepository.SaveChanges();
            }
            catch (DataException dx)
            {

                Console.WriteLine("cant save changes");
            }

            var orderedProducts = orderCreationViewModel.Products.Where(p => p.IsOrdered).Select(s => s.Id);
            foreach (var op in orderedProducts)
            {
                var opderedProduct = new OrderProduct()
                {
                    OrderId = order.Id,
                    ProductId = op
                };
                OrderRepository.AddOrderProduct(opderedProduct);
            }

            try
            {
                OrderRepository.SaveChanges();
            }
            catch (DataException dx)
            {

                Console.WriteLine("cant save changes");
            }
        }
    }
}
