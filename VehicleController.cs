using Domain.Entity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class VehicleController : Controller
    {
        VehicleService Rs = new VehicleService();
        // GET: Reclamation
        public ActionResult Index()
        {
            return View(Rs.GetAll());
        }

        public ActionResult Delete(int id)
        {
            vehicle v = new vehicle();

            v = Rs.GetById(id);
            Rs.Delete(v);
            Rs.Commit();

            return RedirectToAction("Index");
        }


        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(HttpPostedFileBase photo)
        {

            var coleur = Request.Form["couleur"];
            var Immatriculation = Request.Form["imm"];
            var Marque = Request.Form["marque"];
            var Model = Request.Form["Model"];
            var chevaux = Request.Form["ch"];
            var chassis = Request.Form["chassis"];

            vehicle v = new vehicle();
            v.couleur = (coleur);
            v.immatriculation = (Immatriculation);
            v.marque = (Marque);
            v.model = (Model);
            v.nbchevaux = (Int32.Parse(chevaux));
            v.numchassis = (Int32.Parse(chassis));

            Rs.Add(v);
            Rs.Commit();




            return RedirectToAction("Index");
        }


        public ActionResult Update(int id)
        {


            ViewBag.vehicule = Rs.GetById(id);
            return View();

        }

        [HttpPost]
        public ActionResult Update(int id, HttpPostedFileBase photo)
        {

            var coleur = Request.Form["couleur"];
            var Immatriculation = Request.Form["imm"];
            var Marque = Request.Form["marque"];
            var Model = Request.Form["Model"];
            var chevaux = Request.Form["ch"];
            var chassis = Request.Form["chassis"];

            vehicle v = Rs.GetById(id);
            v.couleur = (coleur);
            v.immatriculation = (Immatriculation);
            v.marque = (Marque);
            v.model = (Model);
            v.nbchevaux = (Int32.Parse(chevaux));
            v.numchassis = (Int32.Parse(chassis));

            Rs.Update(v);
            Rs.Commit();




            return RedirectToAction("Index");
        }

    }
}