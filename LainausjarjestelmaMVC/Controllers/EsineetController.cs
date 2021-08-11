using LainausjarjestelmaMVC.Models;
using System;
using System.Collections.Generic;
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

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Esineet esineet = db.Esineet.Find(id);
            if (esineet == null) return HttpNotFound();
            return View(esineet);

        }
    }
}