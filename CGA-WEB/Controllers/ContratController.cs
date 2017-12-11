using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System.Data;

namespace CGA_WEB.Controllers
{
    public class ContratController : Controller
    {
        // contract deserializedProduct;
        // GET: Contrat
        public ActionResult Index()
        {
            var contrats = new RestClient("http://127.0.0.1:18080/cga-web/api/");
            var request = new RestRequest("contract", Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse<List<contract>> contrat = contrats.Execute<List<contract>>(request);
            return View(contrat.Data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(contract c)
        {
            HttpClient contrat = new HttpClient();

            contrat.BaseAddress = new Uri("http://127.0.0.1:18080");
            //deserializedProduct = JsonConvert.DeserializeObject<contract>("cga-web/api/contract", new JavaScriptDateTimeConverter());

            contrat.PostAsJsonAsync<contract>("cga-web/api/contract", c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }

    }
}