using System;
using System.Linq;
using System.Web.Mvc;
using CSRF_StatusUpdate.Data;
using CSRF_StatusUpdate.Models;

namespace CSRF_StatusUpdate.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            using (StatusDbDataContext db = new StatusDbDataContext())
            {
                ViewBag.StatusUpdates = db.Status
                    .Where(s => s.Username == userName)
                    .OrderByDescending(s => s.StatusDateCreated)
                    .Select(s => new StatusUpdate
                        {
                            StatusDate = s.StatusDateCreated, 
                            Status = s.UserStatus
                        }).ToList();
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Index(StatusUpdate model)
        {
            if (ModelState.IsValid)
            {
                using (StatusDbDataContext db = new StatusDbDataContext())
                {

                    var userName = User.Identity.Name;
                    db.Status.InsertOnSubmit(new Status { UserStatus = model.Status, Username = userName, StatusDateCreated = DateTime.Now });
                    db.SubmitChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }
    }
}
