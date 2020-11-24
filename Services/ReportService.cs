using Storage5.Models;
using Storage5.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Storage5.Services
{
    public class ReportService : IReportService
    {
        private IReportRepository ReportRepository;

        public ReportService(IReportRepository ReportRepository)
        {
            this.ReportRepository = ReportRepository;
        }

        public List<OrderInfoViewModel> CreateOrderInfoViewModel()
        {
            List<OrderInfoViewModel> OrderInfoViewModels = new List<OrderInfoViewModel>();
            foreach (var order in ReportRepository.GetAllOrders())
            {
                int currentOrderId = order.Id;
                Customer currentCustomer = ReportRepository.GetAllCustomers().First(c => c.Id == order.CustomerId);
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
                foreach (var op in ReportRepository.GetAllOrderProducts().Where(o => o.OrderId == currentOrderId))
                {
                    Product currentProduct = ReportRepository.GetAllProducts().Where(p => p.Id == op.ProductId).First();
                    orderInfoViewModel.products.Add(currentProduct);
                }
                OrderInfoViewModels.Add(orderInfoViewModel);
            }
            return OrderInfoViewModels;
        }

        public IEnumerable<OrderInfoViewModel> GetReportAfterSearch(int OrderId, int CustomerId, int ProductId)
        {
            return CreateOrderInfoViewModel().Where(o => (CustomerId == 0 || o.CustomerId == CustomerId) &&
                                               (OrderId == 0 || o.OrderId == OrderId) &&
                                               (ProductId == 0 || o.products.Any(p => p.Id == ProductId)));
        }
    }
}