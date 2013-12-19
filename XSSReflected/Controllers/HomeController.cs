using System.Linq;
using System.Web.Mvc;
using XSSReflected.Data;
using XSSReflected.Models;

namespace XSSReflected.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ValidateInput(false)]
        [HttpGet]
        public ActionResult Search(string query)
        {
            SearchModel model = new SearchModel();
            if (!string.IsNullOrEmpty(query))
            {
                using (var context = new NorthwindDataContext())
                {
                    model.SearchString = query;
                    var searchResults = context.Products
                                               .Where(x => x.ProductName.Contains(model.SearchString))
                                               .ToList();

                    model.Results = searchResults;
                }
            }
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Search(SearchModel model)
        {
            using (var context = new NorthwindDataContext())
            {
                var searchResults = context.Products
                    .Where(x => x.ProductName.Contains(model.SearchString))
                    .ToList();

                model.Results = searchResults;
                return View(model);
            }
        }
    }
}
