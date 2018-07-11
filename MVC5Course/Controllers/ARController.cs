using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewTest()
        {
            string model = "model Name";
            return PartialView(model as object);
        }

        public ActionResult FileTest(bool isdownload)
        {
            return isdownload
                ? File(Server.MapPath("~/App_Data/FIFA.jpg"), "image/jpeg", "FIFA.jpg")
                : File(Server.MapPath("~/App_Data/FIFA.jpg"), "image/jpeg");
        }
    }
}