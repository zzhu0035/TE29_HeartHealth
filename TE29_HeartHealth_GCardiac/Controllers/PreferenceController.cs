using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TE29_HeartHealth_GCardiac.Controllers
{
    public class PreferenceController : Controller
    {

        // GET: Preference/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Preference/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
