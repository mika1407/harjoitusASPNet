using LainausjarjestelmaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LainausjarjestelmaMVC.Controllers
{
    public class EsineetController : Controller
    {
        //GET: Esineet
        LainausDBomaEntities1 db = new LainausDBomaEntities1();
        public ActionResult Index()
        {
            List<Esineet> model = db.Esineet.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Esineet esineet = db.Esineet.Find(id);
            if (esineet == null) return HttpNotFound();
            return View(esineet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Katso https://go.microsoft.com/fwlink/?LinkId=317598
        public ActionResult Edit([Bind(Include = "EsineID,EsineenNimi,Lainaaja,LainausPaiva,PalautusPaiva,Omistaja")] Esineet esineet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(esineet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(esineet);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EsineID,EsineenNimi,Lainaaja,LainausPaiva,PalautusPaiva,Omistaja")] Esineet esineet)
        {
            if (ModelState.IsValid)
            {
                db.Esineet.Add(esineet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(esineet);
        }
    }
}