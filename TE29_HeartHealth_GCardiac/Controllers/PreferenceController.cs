using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TE29_HeartHealth_GCardiac.Models;
using Microsoft.AspNet.Identity;

namespace TE29_HeartHealth_GCardiac.Controllers
{
    public class PreferenceController : Controller
    {
        private UserDetailsModels db = new UserDetailsModels();
        private string userId;
        private int maxId;
        private float weight;

        // GET: Preference/Create
        public ActionResult Create(String type)
        {
            userId = User.Identity.GetUserId();
            if (db.UserDetails.Where(s => s.UserId == userId).Count() == 0)
            {
                // 要加新建文档的弹窗
                return RedirectToAction("Index", "UserDetails");
            }
            var requestUrl = "recommend?weight_sel=80&sport_sel=All&diff_sel=0";
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
            userId = User.Identity.GetUserId();
            maxId = db.UserDetails.Where(s => s.UserId == userId).Select(s => s.Id).Max();
            weight = db.UserDetails.Where(s => s.Id == maxId).Select(s => s.Weight).First();
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
    }
}
