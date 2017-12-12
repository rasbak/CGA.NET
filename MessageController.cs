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
    public class MessageController : Controller
    {
        ServiceMessage sc = new ServiceMessage(); 
        // GET: Message
        public ActionResult Index()
        {
            List<messages> list = new List<messages>();
            foreach (var item in sc.GetAll())
            {
                messages acc = new messages();

                acc.idMessage = item.idMessage;
                acc.datePost = item.datePost;
                acc.dateEdit = item.dateEdit;
                acc.contenu = item.contenu;
                acc.idTopic = item.idTopic;
                acc.idPosteur = item.idPosteur;
                list.Add(acc);

            }
            //var list = SC.GetAll();
            return View(list);
        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(int id, MessageModel msgMVC)
        {
            msgMVC.idTopic = id;
            if (!ModelState.IsValid || msgMVC.idTopic == 0)
            {
                RedirectToAction("Create");
            }


            msgMVC.idPosteur = 3;
            msgMVC.nbLike = 0;
            messages msg = new messages();
            msg.idTopic = msgMVC.idTopic;
            msg.datePost = msgMVC.datePost;
            msg.contenu = msgMVC.contenu;
            msg.dateEdit = msgMVC.dateEdit;
            msg.idPosteur = msgMVC.idPosteur;
        
            
            
               
               
                sc.Add(msg);
                sc.Commit();
           

            // Sauvgarde de l'image


            return RedirectToAction("index");

        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MessageModel msgMVC)
        {

            messages msg = sc.GetById(id);
            msg.idMessage = msgMVC.idMessage;
            msg.datePost = msgMVC.datePost;
            msg.dateEdit = msgMVC.dateEdit;
            msg.contenu = msgMVC.contenu;
            msg.idTopic = msgMVC.idTopic;
            msg.idPosteur = msgMVC.idPosteur;



            if (ModelState.IsValid)
            {
                sc.Update(msg);
                sc.Commit();
                return RedirectToAction("index");
            }

            return View();
        }

        // GET: Message/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Message/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                messages acc = sc.GetById(id);
                sc.Delete(acc);
                sc.Commit();
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
    }
}
