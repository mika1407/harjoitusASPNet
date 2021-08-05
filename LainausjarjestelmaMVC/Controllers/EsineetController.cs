using LainausjarjestelmaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LainausjarjestelmaMVC.Controllers
{
    public class EsineetController : Controller
    {
        //GET: Esineet
        public ActionResult Index()
        {
            LainausDBomaEntities db = new LainausDBomaEntities();
            List<Esineet> model = db.Esineet.ToList();
            db.Dispose();
            return View(model);
        }
    }
}