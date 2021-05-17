using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TE29_HeartHealth_GCardiac.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult FAQ()
        {
            ViewBag.Message = "FAQ page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string pwd)
        {
            if(userName == "te29" && pwd == "te29")
            {
                return RedirectToAction("Index");
            } else
            {
                ViewBag.valid = "Invalid username or password!";
                return View();
            }
        }
    }
}