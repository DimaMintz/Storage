using System.Data;
using System.Net;
using System.Web.Mvc;
using Storage5.Models;
using Storage5.Repository;

namespace Storage5.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository ProductRepository;

        public ProductsController()
        {
            this.ProductRepository = RepositoryFactory.CreateRepositoryObject<IProductRepository>(new OrdersContext());
        }
        public ProductsController(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        //show all products
        public ActionResult Index()
        {
            ViewBag.Products = ProductRepository.GetAllProducts();
            return View();
        }

        // move to create page
        public ActionResult Create()
        {
            var product = new Product();
            return View(product);
        }

        //create new product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description,CreationDate,ExpiredDate")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductRepository.AddProduct(product);
                    ProductRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dx)
            {
                ModelState.AddModelError("", dx.ToString());
            }

            return View(product);
        }

        //show product to edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductRepository.GetProductByID((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //edit product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description,CreationDate,ExpiredDate")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductRepository.UpdateProduct(product);
                    ProductRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dx)
            {
                ModelState.AddModelError("", dx.ToString());
            }

            return View(product);
        }

        //show product to delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductRepository.GetProductByID((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //delete product
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Product product = ProductRepository.GetProductByID(id);
                ProductRepository.RemoveProduct(id);
                ProductRepository.SaveChanges();
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
            ProductRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}