using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testing_app.Factory;
using testing_app.Infrastructure;

namespace testing_app.Controllers
{
    public class HomeController : Controller
    {
        private string _heading;

        public HomeController(IHeading heading)
        {
            _heading = heading.Value;
        }
        public ActionResult Index()
        {
            ViewBag.Title = _heading;

            return View();
        }

        public ActionResult Login()
        {
            Session["id"] = 5;
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return Redirect("/Home");
        }

        public ActionResult AboutUs()
        {

            return View();
        }
    }
}
