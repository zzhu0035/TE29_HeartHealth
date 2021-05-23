using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using TE29_HeartHealth_GCardiac.Models;
using Microsoft.AspNet.Identity;
using IronPython.Hosting;
using System.Diagnostics;
using System.IO;

namespace TE29_HeartHealth_GCardiac.Controllers
{
    public class PreferenceController : Controller
    {
        private UserDetailsModels db = new UserDetailsModels();
        private string userId;
        private int maxId;
        private float weight;

        // GET: Preference/Create
        public ActionResult Create(int? choise, string type)
        {
            var weight = 80;
            TempData["type"] = type;
            if (choise == 0)
            {
                ViewBag.choise = 0;
            }
            userId = User.Identity.GetUserId();
            if (db.UserDetails.Where(s => s.UserId == userId).Count() == 0)
            {
                ViewBag.profile = 0;
            } else
            {
                var weightList = db.UserDetails.Where(s => s.UserId == userId).Select(s => s.Weight).ToList();
                weight = weightList[weightList.Count-1];
            }
            var requestUrl = "recommend?weight_sel=" + weight + "&sport_sel=All&diff_sel=0";
            var MOCK_BASE_URL = "http://data.gcardiac.tech:8500/";

            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                UseCookies = false
            };
            var client = new HttpClient(httpClientHandler);
            client.BaseAddress = new Uri(MOCK_BASE_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var rspn = client.GetAsync(requestUrl).Result;
            rspn.EnsureSuccessStatusCode();
            var info = rspn.Content.ReadAsAsync<dynamic>().Result;
            PreferenceViewModels model = new PreferenceViewModels();
            model.exercise = info.ToObject<List<ExerciseModel>>();
            return View(model);
        }

        // POST: Preference/Create
        [HttpPost]
        public ActionResult Create(PreferenceViewModels preferenceViewModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.Identity.GetUserId();
                if(db.UserDetails.Where(s => s.UserId == userId).Count() == 0)
                {
                    return RedirectToAction("Index", "UserDetails", new { profile=0 });
                }
                maxId = db.UserDetails.Where(s => s.UserId == userId).Select(s => s.Id).Max();
                weight = db.UserDetails.Where(s => s.Id == maxId).Select(s => s.Weight).First();
            } else
            {
                weight = 60;
            }
            var requestUrl = "recommend?weight_sel=" + weight + "&sport_sel=" + preferenceViewModel.Sports + "&diff_sel=" + preferenceViewModel.Strength;
            var MOCK_BASE_URL = "http://data.gcardiac.tech:8500/";

            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                UseCookies = false
            };
            var client = new HttpClient(httpClientHandler);
            client.BaseAddress = new Uri(MOCK_BASE_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var rspn = client.GetAsync(requestUrl).Result;
            rspn.EnsureSuccessStatusCode();
            var info = rspn.Content.ReadAsAsync<dynamic>().Result;
            preferenceViewModel.exercise = info.ToObject<List<ExerciseModel>>();
            return View(preferenceViewModel);
        }

        [HttpPost]
        public ActionResult MakePlan()
        {
            string type = (string)TempData["type"];
            string[] exericseStr = Request.Form.GetValues("Exercises");
            List<object> list = new List<object>();
            foreach(string str in exericseStr)
            {
                if (!str.Equals("false"))
                {
                    list.Add(new { Value = str, Text = str });
                }
            }
            if (list.Count == 0)
            {
                return RedirectToAction("Create", new { choise = 0 });
            }
            TempData["exeList"] = list;
            return RedirectToAction("Index", "Plans", new { type = type });
            //return RedirectToAction("MakePlan", "Plan");
        }
    }
}
