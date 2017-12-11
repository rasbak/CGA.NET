using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using Domain.Entities;



namespace CGA_WEB.Controllers
{
    public class UserAdminController : Controller
    {
        // GET: UserAdmin
        public ActionResult Index()
        {
            var users = new RestClient("http://127.0.0.1:18080/cga-web/api/");
            var request = new RestRequest("users", Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse<List<user>> user = users.Execute<List<user>>(request);
            return View(user.Data);
        }
    }
}