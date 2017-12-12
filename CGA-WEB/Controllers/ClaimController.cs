using CGA.Models;
using Domaine.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static iTextSharp.text.Font;

namespace CGA.Controllers
{
    public class ClaimController : Controller
    {


        ClaimService claimService = new ClaimService();

        // GET: Claim
        public ActionResult Index(String searchString)
        {
            List<ClaimModel> List = new List<ClaimModel>();
            foreach (var item in claimService.GetAll())
            {
                ClaimModel cm = new ClaimModel();

                cm.id = item.id;
                cm.etat = item.etat;
                cm.cinInsured2 = item.cinInsured2;
                cm.contract_id = item.contract_id;
                cm.accidentDate = item.accidentDate;
                cm.localisation = item.localisation;

                List.Add(cm);
            }
            var finds = from m in List
                        select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                finds = finds.Where(s => s.localisation.Contains(searchString)).AsEnumerable();
            }

            return View(finds);
        }

        // GET: Claim/Details/5
        public ActionResult Details(int id)
        {
            ClaimModel cm = new ClaimModel();
            claim c = claimService.GetById(id);
            cm.ImageUrl = c.ImageUrl;
            cm.localisation = c.localisation;
            cm.accidentDate = c.accidentDate;
            cm.cinInsured2 = c.cinInsured2;
            cm.injured = c.injured;
            cm.namesAddressesPhonesWitnesses = c.namesAddressesPhonesWitnesses;
            cm.vehiclesDamage = c.vehiclesDamage;
            c.etat = c.etat;
            cm.contract_id = c.contract_id;

            return View(cm);
        }

        // GET: Claim/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(claim cm, HttpPostedFileBase Image, int id)
        {
            if (string.IsNullOrWhiteSpace(cm.cinInsured2) )
            {

                return View(cm);
            }
            {
               cm.ImageUrl = Image.FileName;
            claim c = new claim
            {
                cinInsured2 = cm.cinInsured2,
                contract_id = id,
                accidentDate = cm.accidentDate,
                localisation = cm.localisation,
                lang = cm.lang,
                lat = cm.lat,
                namesAddressesPhonesWitnesses = cm.namesAddressesPhonesWitnesses,
                ImageUrl = cm.ImageUrl,
                otherObjectDamage = cm.otherObjectDamage,
                injured = cm.injured,
                vehiclesDamage = cm.vehiclesDamage,
                etat = "waiting"



            };

        var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
        Image.SaveAs(path);
                claimService.Add(c);
            claimService.Commit();  

            return RedirectToAction("Index");
    }
            
        }
        

        // GET: Claim/Edit/5
        public ActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }
            else
            {
                ClaimModel cm = new ClaimModel();
                claim c = claimService.GetById(id);
                cm.id = c.id;
                cm.ImageUrl = c.ImageUrl;
                cm.localisation = c.localisation;
                cm.accidentDate = c.accidentDate;
                cm.cinInsured2 = c.cinInsured2;
                cm.injured = c.injured;
                cm.namesAddressesPhonesWitnesses = c.otherObjectDamage;
                cm.vehiclesDamage = c.vehiclesDamage;
                c.etat = c.etat;
                cm.contract_id = c.contract_id;

                return View(cm);
            } }

        // POST: Claim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClaimModel cm)
        {
            claim c = claimService.GetById(id);
            c.ImageUrl = cm.ImageUrl;
            c.localisation = cm.localisation;
            c.accidentDate = cm.accidentDate;
            c.cinInsured2 = cm.cinInsured2;
            c.injured = cm.injured;
            c.namesAddressesPhonesWitnesses = cm.otherObjectDamage;
            c.vehiclesDamage = cm.vehiclesDamage;
            c.etat = cm.etat;
            c.contract_id = cm.contract_id;
            claimService.Update(c);
            claimService.Commit();

            return RedirectToAction("Index");

        }
        

        // GET: Claim/Delete/5
        public ActionResult Delete(int id)
        {
            claimService.Delete(claimService.GetById(id));
            claimService.Commit();


            return RedirectToAction("Index");
        }

        // POST: Claim/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ClaimModel cm)
        {
            claim c = claimService.GetById(id);
            c.ImageUrl = cm.ImageUrl;
            c.localisation = cm.localisation;
            c.accidentDate = cm.accidentDate;
            c.cinInsured2 = cm.cinInsured2;
            c.injured = cm.injured;
            c.namesAddressesPhonesWitnesses = cm.otherObjectDamage;
            c.vehiclesDamage = cm.vehiclesDamage;
            c.etat = cm.etat;
            c.contract_id = cm.contract_id;
            claimService.Delete(c);
            claimService.Commit();

            return RedirectToAction("Index");
            }
        }
   
}

