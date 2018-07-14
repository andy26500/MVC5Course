using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            ViewData.Model = "Hello world";
            return View();
        }

        public ActionResult ViewBagTest()
        {
            ViewBag.Msg = "Hello world";
            return View();
        }

        public ActionResult ViewDataTest()
        {
            ViewData["Msg2"] = "Hello world";
            return View();
        }

        public ActionResult TempDataTest()
        {
            TempData["Msg3"] = "Hello world";
            return View();
        }
    }
}