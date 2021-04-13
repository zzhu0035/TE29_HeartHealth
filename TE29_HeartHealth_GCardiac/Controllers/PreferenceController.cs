using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            var requestUrl = "recommend?weight_sel=80&prev_cond_inp=1&sport_sel=Water&cal_select_min=20&cal_select_max=500";
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
            return View();
        }
    }
}
