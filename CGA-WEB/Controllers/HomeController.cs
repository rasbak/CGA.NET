using CGA_WEB.Models;
using Domain.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using Domain;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CGA_WEB.Controllers
{

    public class HomeController : Controller
    {

        ServiceUser su = null;
        ReclamationService rs = null;

        public static string mail;
        public static int idU;


        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModal uvm)
        {


            HttpClient Client = new HttpClient();

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response;
            String cnx = "http://localhost:18080/cga-web/pidev/users/" + uvm.email + "/" + uvm.password;
            if (uvm.email != null && uvm.password != null)

            {
                response = Client.GetAsync(cnx).Result;
                mail = uvm.email;
            }
            else
            {
                response = null;
            }

            if (response.Content.Headers.ContentLength != 0)
            {

                uvm = response.Content.ReadAsAsync<UserViewModal>().Result;

                ViewBag.result = response.Content.ReadAsAsync<UserViewModal>().Result;
                // IEnumerable<Users> u = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;
                if (uvm.role == "administrator")
                {
                    return RedirectToAction("Reclamation", "Reclamation");
                }
                else { 
                return
                    RedirectToAction("Home", uvm);
                     }
            }
            else
            {
                ViewBag.error = "Coordonnées incorrecte! Veuillez réesseyer";
                return View();
            }

        }


        public ActionResult Home(UserViewModal uvm)
        {

            ViewBag.Message = "Your application description page.";
            ViewBag.email = uvm.email;
            return View(uvm);
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET : Home/Profil/4
        public ActionResult Profil(int id)
        {
            user u = null;
            su = new ServiceUser();
            u = su.GetById(id);
            UserViewModal uvm = new UserViewModal();
            uvm.id = u.id;
            uvm.lastName = u.lastName;
            uvm.firstName = u.firstName;
            uvm.email = u.email;
            uvm.role = u.role;
            uvm.driverLN = u.driverLicenseNumber;
            uvm.expertiseLevel = u.expertiseLevel;
            ViewBag.user = uvm;
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Profil(ReclmationViewModel rvm)
        {
            su = new ServiceUser();
            rs = new ReclamationService();
            report r = new report();
            r.Content = rvm.Content;
            r.subject = rvm.subject;
            r.vu = 0;
            if (mail != null) {
                user u = su.Get(us => us.email == mail);
                r.name = u.firstName;
                r.lastName = u.lastName;
                r.insured_id = u.id;
               
                idU = u.id;
            }
            rs.Add(r);
            rs.Commit();

            su.email(rvm.Email, rvm.pass, rvm.subject, rvm.Content);
            ViewBag.Message = "Your Profile page.";

            return RedirectToAction("Profil", new
            {
                id = idU

        } );
        }


       
    }
}