using Storage5.Models;
using System.Collections.Generic;

namespace Storage5.Services
{
    public interface IReportService
    {
        List<OrderInfoViewModel> CreateOrderInfoViewModel();
        IEnumerable<OrderInfoViewModel> GetReportAfterSearch(int OrderId, int CustomerId, int ProductId);
    }
}
