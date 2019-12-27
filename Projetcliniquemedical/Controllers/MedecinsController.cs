using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Projetcliniquemedical.Models;

namespace Projetcliniquemedical.Controllers
{
    public class MedecinsController : Controller
    {
        private OurDbContext db = new OurDbContext();

        // GET: Medecins
        public ActionResult Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // lena tzid eka parametre
            var response = client.GetAsync(client.BaseAddress + "/Medecins").Result;

            //testi ken reponse jetek avec succés
            if (response.IsSuccessStatusCode)
            {   //te5ou contenu
                var data = response.Content.ReadAsStringAsync().Result;
                var meds = new List<Medecin>();
                //bon f cas mte3i recuperit un objet donc na3melou conversion f eka "med"
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), meds);
                return View(meds);
            }
            else
            {
                return HttpNotFound();
            }

            //var medecin = db.medecin.Include(m => m.UserAccount);
            //return View(medecin.ToList());
        }

        // GET: Medecins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/Medecins/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var med = new Medecin();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), med);

                if (med == null)
                {
                    return HttpNotFound();
                }
                return View(med);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Medecins/Create
        public ActionResult Create()
        {
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceNom");
            ViewBag.UserID = new SelectList(db.userAccount, "UserID", "Email");
            return View();
        }

        // POST: Medecins/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedecinID,MedecinNom,MedecinPrenom,UserID,ServiceID")] Medecin medecin)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (ModelState.IsValid)
            {
                var response = client.PostAsJsonAsync(client.BaseAddress + "/Medecins/", medecin).Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var med = new Medecin();
                    Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), med);

                    if (med == null)
                    {
                        return HttpNotFound();
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }
            }

            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceNom", medecin.ServiceID);
            ViewBag.UserID = new SelectList(db.userAccount, "UserID", "Email", medecin.UserID);
            return View(medecin);
        }

        // GET: Medecins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/Medecins/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var med = new Medecin();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), med);

                if (med == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceNom", med.ServiceID);
                ViewBag.UserID = new SelectList(db.userAccount, "UserID", "Email", med.UserID);
                return View(med);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Medecins/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedecinID,MedecinNom,MedecinPrenom,UserID,ServiceID")] Medecin medecin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medecin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceNom", medecin.ServiceID);
            ViewBag.UserID = new SelectList(db.userAccount, "UserID", "Email", medecin.UserID);
            return View(medecin);
        }

        // GET: Medecins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/Medecins/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var med = new Medecin();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), med);

                if (med == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceNom", med.ServiceID);
                ViewBag.UserID = new SelectList(db.userAccount, "UserID", "Email", med.UserID);
                return View(med);
            }
            else
            {
                return HttpNotFound();
            }

        }

        // POST: Medecins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.DeleteAsync(client.BaseAddress + "/Medecins/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var med = new Medecin();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), med);

                if (med == null)
                {
                    return HttpNotFound();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

