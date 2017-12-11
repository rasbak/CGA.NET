using CGA_WEB.Models;
using Data;
using Domain.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CGA_WEB.Controllers
{
    public class ReclamationController : Controller
    {
        ServiceUser us = new ServiceUser();
        ReclamationService rs = null;
        // GET: Reclamation
        public ActionResult Reclamation()
        {
            List<ReclmationViewModel> rvms = new List<ReclmationViewModel>();
            rs = new ReclamationService();
            us = new ServiceUser();
            foreach (var item in rs.GetMany(r=>r.vu==0))
            {
                ReclmationViewModel rvm = new ReclmationViewModel();
                rvm.id = item.id;
                rvm.subject = item.subject;
                rvm.Content = item.Content;
                rvm.name = item.name;
                rvm.lastName = item.lastName;
                rvm.role = us.Get(us=>us.id==item.insured_id).role;
                rvms.Add(rvm);
            }


            return View(rvms);
            
        }
        public ActionResult Archive()
        {
            List<ReclmationViewModel> rvms = new List<ReclmationViewModel>();
            us = new ServiceUser();
            rs = new ReclamationService();
            foreach (var item in rs.GetMany(r => r.vu == 1))
            {
                ReclmationViewModel rvm = new ReclmationViewModel();
                rvm.id = item.id;
                rvm.subject = item.subject;
                rvm.Content = item.Content;
                rvm.name = item.name;
                rvm.lastName = item.lastName;
                rvm.role = us.Get(us => us.id == item.insured_id).role;
                rvms.Add(rvm);
            }


            return View(rvms);
        }
        // GET : Reclamation/Reclamation/5
        public ActionResult ToArchive(int id)
        {
            rs = new ReclamationService();
            report rep = rs.GetById(id);
            rep.vu = 1;
            rs.Update(rep);
            rs.Commit();

            return RedirectToAction("Reclamation");

        }

        // GET : Reclamation/Archive/5
        public ActionResult Delete(int id)
        {
            rs = new ReclamationService();
            
            rs.Delete(r=>r.id==id);
            rs.Commit();
            return RedirectToAction("Archive");
        }

        public Chart BillChart()
        {
            var context = new CGAContext();
            var CountM = context.report.SqlQuery("Select * from report where vu=1").Count();
            var CountF = context.report.SqlQuery("Select * from report where vu=0").Count();
           return new Chart(width: 466, height: 500).AddSeries(chartType: "pie", xValue: new[] { CountM+" Archivée(s)", CountF+" Non Vu(s)" }, yValues: new[] { CountM, CountF }).Write("png");
         

        }

    }
}