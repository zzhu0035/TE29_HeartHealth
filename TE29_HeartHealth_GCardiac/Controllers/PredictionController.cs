using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TE29_HeartHealth_GCardiac.Models;

namespace TE29_HeartHealth_GCardiac.Controllers
{
    public class PredictionController : Controller
    {
        private UserDetailsModels db = new UserDetailsModels();

        // GET: Prediction/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prediction/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Prediction prediction)
        {
            //age_value=56&sex_value=0&cp_value=1&trestbps_value=140&chol_value=290&fbs_value=1&rest_ecg_value=1&thalach_value=140&exang_value=1&oldpeak_value=0&slope_value=0&ca_value=0&thal_value=1
            var userId = User.Identity.GetUserId();
            var age = db.UserDetails.Where(s => s.UserId == userId).Select(s => s.Age).First();
            var fbs = 0;
            if (prediction.chol > 120)
            {
                fbs = 1;
            }
            TryValidateModel(prediction);
            if (!ModelState.IsValid)
            {
                return View(prediction);
            }
            var requestUrl = "age_value=" + age +
                "&sex_value=" + prediction.sex +
                "&cp_value=" + prediction.cp +
                "&trestbps_value=" + prediction.trestbps +
                "&chol_value=" + prediction.chol +
                "&fbs_value=" + fbs +
                "&rest_ecg_value=" + prediction.restecg +
                "&thalach_value=" + prediction.thal +
                "&exang_value=" + prediction.exang +
                "&oldpeak_value=" + prediction.oldpeak +
                "&slope_value=" + prediction.slope +
                "&ca_value=0&thal_value=" + prediction.ca;
            var MOCK_BASE_URL = "http://128.199.195.38:5000/recommend/";

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
            double result = Convert.ToDouble(info["Result"]);
            return RedirectToAction("Result", new { result = result });
        }

        [Authorize]
        public ActionResult Result(double? result)
        {
            if(result == null)
            {
                return RedirectToAction("Create");
            }
            if(result > 60)
            {
                ViewBag.color = "red";
            } else if (result > 40 && result <= 60)
            {
                ViewBag.color = "yellow";
            } else
            {
                ViewBag.color = "green";
            }
            ViewBag.result = result;
            return View();
        }
    }
}
