using System.Web.Mvc;
using Storage5.Models;
using Storage5.Repository;
using Storage5.Services;

namespace Storage5.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportRepository ReportRepository;
        private readonly IReportService ReportService;

        public ReportsController()
        {
            this.ReportRepository = RepositoryFactory.CreateRepositoryObject<IReportRepository>(new OrdersContext());
            this.ReportService = new ReportService(ReportRepository);
        }
        public ReportsController(IReportRepository ReportRepository, IReportService ReportService)
        {
            this.ReportRepository = ReportRepository;
            this.ReportService = ReportService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.OrderProducts = ReportService.CreateOrderInfoViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult Index(int OrderId, int CustomerId, int ProductId)
        {
            var viewModel = ReportService.GetReportAfterSearch(OrderId, CustomerId, ProductId);
            ViewBag.OrderProducts = viewModel;
            return View(viewModel);
        }

        //close db
        protected override void Dispose(bool disposing)
        {
            ReportRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}      

