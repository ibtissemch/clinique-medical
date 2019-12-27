using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Projetcliniquemedical.Models;

namespace Projetcliniquemedical.Controllers
{
    public class ServicesController : Controller
    {
        private OurDbContext db = new OurDbContext();

        // GET: Services
        public ActionResult Index()
        {
            var client = new HttpClient();
            // t7ot url 
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // lena tzid eka parametre
            var response = client.GetAsync(client.BaseAddress + "/Services").Result;

            //testi ken reponse jetek avec succés
            if (response.IsSuccessStatusCode)
            {   //te5ou contenu
                var data = response.Content.ReadAsStringAsync().Result;
                var services = new List<Service>();
                //bon f cas mte3i recuperit un objet donc na3melou conversion f eka "med"
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), services);
                return View(services);
            }
            else
            {
                return HttpNotFound();
            }
            //return View(db.Services.ToList());
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Services services = db.Services.Find(id);

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/Services/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var service = new Service();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), service);

                if (service == null)
                {
                    return HttpNotFound();
                }
                return View(service);
            }
            else
            {
                return HttpNotFound();
            }

        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceID,ServiceNom")] Service service)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (ModelState.IsValid)
            {
                var response = client.PostAsJsonAsync(client.BaseAddress + "/Services/", service).Result;


                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var serv = new Service();
                    Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), serv);

                    if (serv == null)
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

            return View(service);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/Services/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var service = new Service();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), service);

                if (service == null)
                {
                    return HttpNotFound();
                }
                return View(service);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Services/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceID,ServiceNom")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress + "/Services/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var service = new Service();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), service);

                if (service == null)
                {
                    return HttpNotFound();
                }
                return View(service);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61585/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.DeleteAsync(client.BaseAddress + "/Services/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var service = new Service();
                Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), service);

                if (service == null)
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
