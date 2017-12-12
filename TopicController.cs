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
    public class TopicController : Controller
    {
        TopicService sc = new TopicService(); 
        // GET: Topic
        public ActionResult Index()
        {
            List<topic> list = new List<topic>();
            foreach (var item in sc.GetAll())
            {
                topic topic = new topic();
                topic.idTopic = item.idTopic;
                topic.dateCreation = item.dateCreation;
                topic.lastpost = item.lastpost;
                topic.sujet = item.sujet;
                topic.idCreateur = item.idCreateur;
                topic.contenu = item.contenu;
                
                
                list.Add(topic);

            }
            //var list = SC.GetAll();
            return View(list);
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Topic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult Create(topicModel topicMVC)
        {
            topicMVC.idCreateur = 3;
             topic topic = new topic();
            topic.idTopic = topicMVC.idTopic;
            topic.dateCreation = topicMVC.dateCreation;
            topic.lastpost = topicMVC.lastpost;
            topic.sujet = topicMVC.sujet;
            topic.idCreateur = topicMVC.idCreateur;
            topic.contenu = topicMVC.contenu;


            sc.Add(topic);
            sc.Commit();
            // Sauvgarde de l'image

        
            return RedirectToAction("index");

        }

        // GET: Topic/Edit/5
        public ActionResult Edit(int id)
        {
            topic topic = sc.GetById(id);
            topicModel topicMVC = new topicModel
            {
                idCreateur = topic.idCreateur  ,
                dateCreation = topic.dateCreation , 
                lastpost = topic.lastpost , 
                contenu = topic.contenu , 
                sujet = topic.sujet , 
                idTopic = topic.idTopic
                
                

            };
            sc.Update(topic);
            sc.Commit();
            return View(topicMVC);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, topicModel topicMVC)
        {
                topic topic = sc.GetById(id);
            topic.idCreateur = topicMVC.idCreateur;
                topic.idCreateur = topicMVC.idCreateur;
                topic.dateCreation = topicMVC.dateCreation;
                topic.lastpost = topicMVC.lastpost;
                topic.contenu = topicMVC.contenu;
                topic.sujet = topicMVC.sujet;
           


            if (ModelState.IsValid)
            {
                sc.Update(topic);
                sc.Commit();
                return RedirectToAction("index");
            }

            return View();
        }

        // GET: Topic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Topic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                topic acc = sc.GetById(id);
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
