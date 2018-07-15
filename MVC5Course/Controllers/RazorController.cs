using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class RazorController : Controller
    {
        // GET: Razor
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}