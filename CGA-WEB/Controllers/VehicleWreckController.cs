using CGA_WEB.Models;
using Data;
using Domain.Entities;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using PagedList;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CGA_WEB.Controllers
{
    public class VehicleWreckController : Controller
    {
        VehiclewreckService vs = null;
        Model1 m1;

        public VehicleWreckController()
        {
            vs = new VehiclewreckService();

           
        }
        private CGAContext cc = new CGAContext();
        // GET: VehicleWreck
        public ActionResult Index(string option, string search, int? pageNumber)
        {
           
            var vrecks = vs.GetAll();
            List<VehiclewreckModel> vm = new List<VehiclewreckModel>();
            foreach (var item in vrecks)
            {
                vm.Add(
                    new VehiclewreckModel
                    {
                        vehicleId=item.id,
                        numchassis=item.numchassis,
                        couleur=item.couleur,
                        description=item.description,
                        modele=item.modele


                    });
            }

            ViewData["count"] = vs.count();

            //if a user choose the radio button option as Subject  
            if (option == "numchassis")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  

                return View(vm.Where(x =>x.numchassis == search || search == null).ToList().ToPagedList(pageNumber ?? 1, 10));
            }
            else if (option == "couleur")
            {
                return View(vm.Where(x => x.couleur == search || search == null).ToList().ToPagedList(pageNumber ?? 1, 10));
            }
            else if (option == "description")
            {
                return View(vm.Where(x => x.description == search || search == null).ToList().ToPagedList(pageNumber ?? 1, 10));
            }
            else
            {
                return View(vm.Where(x => x.modele == search || search == null).ToList().ToPagedList(pageNumber ?? 1, 10));
            }
            return View(cc.vehiclewreck.OrderByDescending(x => x.id).ToPagedList(pageNumber ?? 1, 10));
        }




        // GET: VehicleWreck/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleWreck/Create
        [AllowAnonymous]

        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleWreck/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HandleError(View = "/Shared/Error.cshtml")]
        public ActionResult Create(VehiclewreckModel vm)
        {
            vehicleswreck vreck = new vehicleswreck()

            {
                
            numchassis = vm.numchassis,
                couleur=vm.couleur,
                description=vm.description,
                modele=vm.modele



            };

            if (string.IsNullOrEmpty(vm.numchassis))
            {
                ModelState.AddModelError("numchassis", "Please Enter vin number");
            }

            if (ModelState.IsValid)
            {
                vs.Add(vreck);
                vs.Commit();
            }
            return RedirectToAction("Index");

        }

        // GET: VehicleWreck/Edit/5
        public ActionResult Edit(int id)
        {
            var vrecks = vs.GetById(id);
            VehiclewreckModel vm = new VehiclewreckModel();

            vm.numchassis = vrecks.numchassis;
            vm.description = vrecks.description;
            vm.couleur = vrecks.couleur;
            vm.modele = vrecks.modele;

            return View(vm);
        }

        // POST: VehicleWreck/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehiclewreckModel vmodel)
        {
            if (!ModelState.IsValid )
            {
                RedirectToAction("Create");
            }
            vehicleswreck v = vs.GetById(id);
            v.modele = vmodel.modele;
            v.numchassis = vmodel.numchassis;
            v.description = vmodel.description;
            v.couleur = vmodel.couleur;
            vs.Update(v);
            vs.Commit();


            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleWreck/Delete/5
        public ActionResult Delete(int id, VehiclewreckModel vmodel)
        {
            var vreck = vs.GetAll();
            List<VehiclewreckModel> vwmodel = new List<VehiclewreckModel>();
            foreach(var item in vreck)
            {
                vwmodel.Add(new VehiclewreckModel
                {
                    vehicleId=item.id,
                    couleur=item.couleur,
                    description=item.description,
                    numchassis=item.numchassis,
                    modele=item.modele
                }


                    );
                    }
            var vferailler = vwmodel.Where(a => a.vehicleId == id).FirstOrDefault();
            if (vferailler == null)
            {
                return RedirectToAction("Index");
            }
            return View(vferailler);
        }

        // POST: VehicleWreck/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string confirmButton)
        {
            vehicleswreck vrecked = vs.GetById(id);
            if (vrecked == null)
                return View("not found");
            vs.Delete(vrecked);
            vs.SaveChange();
            return RedirectToAction("Index");

        }


        public void GeneratePDF(int id)
        {


            var ev = vs.GetById(id);

            vehicleswreck d = new vehicleswreck
            {

                numchassis = ev.numchassis,
                modele = ev.modele,
                description = ev.description,
                couleur=ev.couleur
            };


            using (MemoryStream ms = new MemoryStream())
            using (Document document = new Document(PageSize.A4, 25, 25, 30, 30))
            using (PdfWriter writer = PdfWriter.GetInstance(document, ms))
            {
                document.Open();
                string imageURL = Server.MapPath(".") + "/Capture.png";

                StringBuilder sb = new StringBuilder();
                sb.Append("<header class='clearfix'>");
                sb.Append("<h1>CGA 4GL2</h1>");
                sb.Append("</div>");
                sb.Append("<div id='project'>");
                sb.Append("<div><span>PROJECT:</span> CGA</div>");
                sb.Append("<div><span>ADDRESS:</span> Tunisia </div>");
                sb.Append("<div><span>EMAIL:</span> <a href='mailto:houssem.ouali@esprit.tn'>houssem.ouali@esprit.tn</a></div>");
                sb.Append("<div><span>DATE</span> December 12, 2017</div>");
                sb.Append("</div>");
                sb.Append("</header>");
                sb.Append("<footer>");
                sb.Append("</footer>");

                StringReader sr = new StringReader(sb.ToString());
                HTMLWorker htmlparser = new HTMLWorker(document);
                htmlparser.Parse(sr);

                document.Add(new Paragraph("Registration number :" + d.numchassis));
                document.Add(new Paragraph("Color : " + d.couleur));
                document.Add(new Paragraph("Description : " + d.description));
                document.Add(new Paragraph("Model : " + d.modele));

                document.Close();
                writer.Close();
                ms.Close();
                Response.ContentType = "pdf/application";
                Response.AddHeader("content-disposition", "attachment;filename=CGA_vehicleWrecked.pdf");
                Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            }



        }

        //[HttpPost]
        //public ContentResult AjaxMethod(string colors)
        //{
        //    string query = "SELECT couleur, COUNT(Id)";
        //    query += " FROM vehiclewreck WHERE couleur = @color GROUP BY id";
        //    string constr = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
        //    StringBuilder sb = new StringBuilder();
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = con;
        //            cmd.Parameters.AddWithValue("@Country", colors);
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                sb.Append("[");
        //                while (sdr.Read())
        //                {
        //                    sb.Append("{");
        //                    System.Threading.Thread.Sleep(50);
        //                    string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
        //                    sb.Append(string.Format("text :'{0}', value:{1}, color: '{2}'", sdr[0], sdr[1], color));
        //                    sb.Append("},");
        //                }
        //                sb = sb.Remove(sb.Length - 1, 1);
        //                sb.Append("]");
        //            }

        //            con.Close();
        //        }
        //    }

        //    return Content(sb.ToString());
        //}



    }
}
