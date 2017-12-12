using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using Domaine.Entity;

namespace CGA.Controllers
{
    public class MyContractController : Controller
    {
        // GET: MyContract
        public ActionResult Index()
        {
            var contrats = new RestClient("http://localhost:18080/cga-web/rest/");
            var request = new RestRequest("contract/1", Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse<List<contract>> contrat = contrats.Execute<List<contract>>(request);
            return View(contrat.Data);
        }

    }
}