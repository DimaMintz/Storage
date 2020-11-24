using System.Data;
using System.Net;
using System.Web.Mvc;
using Storage5.Models;
using Storage5.Repository;

namespace Storage5.Controllers
{
    public class StatusesController : Controller
    {
        private readonly IStatusRepository StatusRepository;

        public StatusesController()
        {
            this.StatusRepository = RepositoryFactory.CreateRepositoryObject<IStatusRepository>(new OrdersContext());
        }
        public StatusesController(IStatusRepository StatusRepository)
        {
            this.StatusRepository = StatusRepository;
        }

        //show all statuses
        public ActionResult Index()
        {
            ViewBag.Statuses = StatusRepository.GetAllStatuses();
            return View();
        }

        // move to create page
        public ActionResult Create()
        {
            return View();
        }

        //create new status
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Status status)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StatusRepository.AddStatus(status);
                    StatusRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dx)
            {
                ModelState.AddModelError("", dx.ToString());
            }

            return View(status);
        }

        //show status to edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = StatusRepository.GetStatusByID((int)id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        //edit status
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Status status)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StatusRepository.UpdateStatus(status);
                    StatusRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dx)
            {
                ModelState.AddModelError("", dx.ToString());
            }

            return View(status);
        }

        //show status to delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = StatusRepository.GetStatusByID((int)id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        //delete status
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Status status = StatusRepository.GetStatusByID((int)id);
                StatusRepository.RemoveStatus(id);
                StatusRepository.SaveChanges();
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
            StatusRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}