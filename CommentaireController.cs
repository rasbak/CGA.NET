using CGA_WEB.Models;
using Domain.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGA_WEB.Controllers
{
    public class CommentaireController : Controller
    {

        CommentaireService cmS = null;
        public CommentaireController()
        {
            cmS = new CommentaireService();

        }


        // GET: Commentaire
        public ActionResult Index()
        {

            ViewData["nbre"]= cmS.nbreCommentaireByPolicy(1);
            var x = cmS.sortById();
           
            return View(x);
        }

        // GET: Commentaire/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Commentaire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Commentaire/Create
        [HttpPost]
        public ActionResult Create(String txt)
        {

            List<String> verif = new List<String>();


            commentaire com = new commentaire()


            {


                policy_id = 2,
                text = txt,
                user_id = 1,

            };

            {
                
                Char delimiter = ' ';
                String[] substrings = txt.Split(delimiter);
                foreach (var substring in substrings)
                    verif.Add(substring);
            }
            if (verif.Contains("asba"))
            {
                ViewBag.MessageErreur = "this commentaire contais bad word";
                return RedirectToAction("Index");
            }
            else
            {
                cmS.Add(com);
                cmS.Commit();
                ViewBag.err = "this commentaire contais bad word";

                return RedirectToAction("Index");
            }
        }

        // GET: Commentaire/Edit/5
        public ActionResult Edit(int id)
        {
            commentaire com = cmS.GetById(id);
            
            CommentaireModels CM = new CommentaireModels()
            {
                text = com.text,
                id=com.id,


            };

            return View(CM);
        }

        // POST: Commentaire/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CommentaireModels CM)
        {
            commentaire com = cmS.GetById(id);


            com.text = CM.text;
           
               cmS.Update(com);
                UpdateModel(CM);

               cmS.Commit();
                return RedirectToAction("Index");


           
           

            
        }

        // GET: Commentaire/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    commentaire com = cmS.GetById(id);
        //    if (com == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    CommentaireModels CM= new CommentaireModels()
        //    {
        //        text =com.text,
               


        //    };

        //    return View(CM);
        //}

        // POST: Commentaire/Delete/5
       
        public ActionResult Delete(int id)
        {
            commentaire com = cmS.GetById(id);
            cmS.Delete(com);
            cmS.Commit();
          
            return RedirectToAction("Index");
        }

        public ActionResult nbreCommentaire()
        {
            int x = cmS.nbreCommentaireByPolicy(1);

            return View(x);
        }



    }
}
