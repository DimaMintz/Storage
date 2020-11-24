using System.Data;
using System.Net;
using System.Web.Mvc;
using Storage5.Models;
using Storage5.Repository;
using Storage5.Services;

namespace Storage5.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository OrderRepository;
        private readonly IOrderService OrderService;

        public OrdersController()
        {
            this.OrderRepository = RepositoryFactory.CreateRepositoryObject<IOrderRepository>(new OrdersContext());
            this.OrderService = new OrderService(OrderRepository);
        }
        public OrdersController(IOrderRepository OrderRepository, IOrderService OrderService)
        {
            this.OrderRepository = OrderRepository;
            this.OrderService = OrderService;
        }

        //show all orders
        public ActionResult Index()
        {
            ViewBag.OrderProducts = OrderService.CreateOrderInfoViewModel();
            return View();
        }

        // move to create page
        public ActionResult Create()
        {
            ViewBag.CustomersList = OrderService.ListOfCustomers();
            return View(OrderService.ListOfProducts());
        }

        //create new order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreationViewModel orderCreationViewModel)
        {
            OrderService.CreateOrderWithProducts(orderCreationViewModel);
            return RedirectToAction("Index");
        }

        //show order to delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = OrderRepository.GetOrderByID((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //delete order
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Order order = OrderRepository.GetOrderByID((int)id);
                OrderRepository.RemoveOrder(id);
                OrderRepository.SaveChanges();
            }
            catch (DataException dx)
            {
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        //close db
        protected override void Dispose(bool disposing)
        {
            OrderRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
