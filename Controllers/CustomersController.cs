using System.Data;
using System.Net;
using System.Web.Mvc;
using Storage5.Models;
using Storage5.Repository;

namespace Storage5.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository CustomerRepository;

        public CustomersController()
        {
            this.CustomerRepository = RepositoryFactory.CreateRepositoryObject<ICustomerRepository>(new OrdersContext());
        }
        public CustomersController(ICustomerRepository CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;
        }

        //show all customers
        public ActionResult Index()
        {
            ViewBag.Customers = CustomerRepository.GetAllCustomers();
            return View();
        }

        // move to create page
        public ActionResult Create()
        {
            return View();
        }

        //create new customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fname,Lname,Address,Phone")] Customer customer)
        {
            try
            {
                if (ModelState.IsValid) //check if any model errors have been added to ModelState
                {
                    CustomerRepository.AddCustomer(customer);
                    CustomerRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException dx)
            {
                ModelState.AddModelError("", dx.ToString());
            }

            return View(customer);
        }

        //show the customer to edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = CustomerRepository.GetCustomerByID((int)id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //edit the customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fname,Lname,Address,Phone")] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerRepository.UpdateCustomer(customer);
                    CustomerRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dx)
            {
                ModelState.AddModelError("", dx.ToString());
            }
            return View(customer);
        }

        //show the customer to delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = CustomerRepository.GetCustomerByID((int)id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //delete the customer
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Customer customer = CustomerRepository.GetCustomerByID((int)id);
                CustomerRepository.RemoveCustomer(id);
                CustomerRepository.SaveChanges();
            }
            catch (DataException dx)
            {
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        //close db connections
        protected override void Dispose(bool disposing) 
        {
            CustomerRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
