using Projetcliniquemedical.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projetcliniquemedical.Controllers
{
    public class RdvController : Controller
    {
        // GET: Rdv
        OurDbContext db = new OurDbContext ();
        public ActionResult RendezVous()
        {
            ViewBag.Userid = Session["UserID"];


            var data = db.rdv.ToList();
            return View(data);
        }
    }
}