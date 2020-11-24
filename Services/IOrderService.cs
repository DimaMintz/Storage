using Storage5.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Storage5.Services
{
    public interface IOrderService
    { 
            List<OrderInfoViewModel> CreateOrderInfoViewModel();

            List<SelectListItem> ListOfCustomers();

            OrderCreationViewModel ListOfProducts();

            void CreateOrderWithProducts(OrderCreationViewModel orderCreationViewModel);
    }
}
