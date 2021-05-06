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
        public ActionResult Create(String type)
        {
            test();
            userId = User.Identity.GetUserId();
/*            if (db.UserDetails.Where(s => s.UserId == userId).Count() == 0)
            {
                // 要加新建文档的弹窗
                return RedirectToAction("Index", "UserDetails");
            }*/
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
            if(User.Identity.IsAuthenticated)
            {
                userId = User.Identity.GetUserId();
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
            string[] exericseStr = Request.Form.GetValues("Exercises");
            List<string> list = new List<string>();
            list.Add("None");
            foreach(string str in exericseStr)
            {
                if (!str.Equals("false"))
                {
                    list.Add(str);
                }
            }
            TempData["exeList"] = list;
            return RedirectToAction("MakePlan", "Plan");
        }

        public void test()
        {
            Process p = new Process();
            var path = Server.MapPath("~/") + @"Python\\prediction.py";
            p.StartInfo.FileName = @"F:\python3\Python37\python.exe";
            //string args = path + " 48 1 1 140 290 1 1 140 1 0 0 0 1";
            p.StartInfo.Arguments = path;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(p.StartInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                    Console.WriteLine(result);
                }
            }
        }
    }
}
